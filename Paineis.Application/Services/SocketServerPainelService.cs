using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Paineis.Application.DTOs;
using Paineis.Application.Interfaces;
using Paineis.Domain.Entities;
using Paineis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Paineis.Application.Services
{
    public class SocketServerPainelService : ISocketServerPainelService
    {

        //private readonly ICorRepository _corRepository;
        private readonly IPainelRepository _ipRepository;
        private readonly IFilaRepository _filaRepository;
        //private CancellationToken cancellationToken;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public SocketServerPainelService(/*ICorRepository corRepository,*/ IPainelRepository ipRepository, IFilaRepository filaRepository, IMapper mapper, IMemoryCache cache)
        {
            //_corRepository = corRepository;
            _ipRepository = ipRepository;
            _filaRepository = filaRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<AlertasModel[]> EnvioGeral(List<AlertasModelNovo> request, string matricula)
        {
            await CriaFila(request, matricula);
            //await StartSendingMessages(cancellationToken);

            AlertasModel[] novaInstancia = new AlertasModel[]
            {
        new AlertasModel
        {
            Mensagem = "Cadastro realizado"
        }
            };

            return novaInstancia;
        }

        public async Task<AlertasModel[]> EnvioGeralUnico(List<AlertasModelNovo> request, string matricula)
        {
            await CriaFilaUnica(request, matricula);
            //await StartSendingMessages(cancellationToken);

            AlertasModel[] novaInstancia = new AlertasModel[]
            {
        new AlertasModel
        {
            Mensagem = "Cadastro realizado"
        }
            };

            return novaInstancia;
        }

        public async Task<bool> EnvioTeste(Mute request)
        {

            try
            {
                // Itera sobre cada IP e porta no painel
               
                string messageHex = "\x18\x00" + "l\x1\x92\x92" + "0\x02TESTE PAINEL \x3S1\x0";

                // Cria o socket
                using Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    // Conecta ao servidor
                    socket.Connect(request.Ip, request.Porta);

                    // Envia a mensagem
                    byte[] bytesToSend = Encoding.Latin1.GetBytes(messageHex);
                    socket.Send(bytesToSend);

                    Console.WriteLine($"Mensagem enviada com sucesso para o IP: {request.Ip}");

                return true; // Indica que a operação foi bem-sucedida
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao enviar mensagem: {e.Message}");

                return false; // Indica que a operação foi bem-sucedida
            }

      
        }

        public async Task<bool> MutePainel(Mute painel)
        {
            try
            {
                string messageHex = "\x02\x00" + "S0";

                // Cria o socket
                using Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Conecta ao servidor
                socket.Connect(painel.Ip, painel.Porta);

                // Envia a mensagem
                byte[] bytesToSend = Encoding.Latin1.GetBytes(messageHex);
                socket.Send(bytesToSend);

                Console.WriteLine($"Painel mutado, IP: {painel.Ip}");

                return true; // Indica que a operação foi bem-sucedida
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao enviar mensagem: {e.Message}");
                return false; // Indica que a operação falhou
            }
        }

        public async Task StartSendingMessages(CancellationToken cancellationToken)
        {

            while (!cancellationToken.IsCancellationRequested)
            {

                var grupos = await ObterGruposDoBancoDeDados();

                foreach (var grupo in grupos)
                {

                    int grupoInt = Convert.ToInt32(grupo);

                    // Obtenha as mensagens da tabela T_FILA
                    var response = await PegaFilaGrupo(grupoInt);

                    await SendMessageToPainel(response); // Envia a mensagem para o painel
                    await Task.Delay(TimeSpan.FromSeconds(26), cancellationToken); // Aguarda 26 segundos antes de verificar novamente
                
                }
             
            }
        }

        public async Task<List<int>> ObterGruposDoBancoDeDados()
        {
            var res = await _filaRepository.FilaGrupos();

            var grupos = res.Select(r => r.CodigoFilaMsg).ToList();

            return grupos;
        }

        public async Task<string> SendMessageToPainel(IEnumerable<FilaDTO> request)
        {
            List<string> failedAlerts = new List<string>();
            List<string> successfulAlerts = new List<string>();
            string resultMessage = "";

            try
            {
                foreach (var linha in request)
                {
                    try
                    {
                        string ip = await PegaIp(linha.FilaAreaCodigoEnvio);

                        int valorSomaAscii = linha.FilaMsgDesc.Length;
                        int valorSomaAsciiTotal = valorSomaAscii + 19;
                        char meuCaractere = (char)valorSomaAsciiTotal;

                        string bitCor = "";
                        switch (await PegaCor(linha.FilaMsgAlerta))
                        {
                            case "Verde":
                                bitCor = "\x92\x92";
                                break;
                            case "Azul":
                                bitCor = "\x96\x96";
                                break;
                            case "Amarelo":
                                bitCor = "\x93\x93";
                                break;
                            case "Vermelho":
                                bitCor = "\x91\x91";
                                break;
                            case "Laranja":
                                bitCor = "\x93\x91";
                                break;
                            default:
                                break;
                        }

                        Console.WriteLine("Valor: " + linha.FilaMsgAlerta);

                        string messageHex = $"{meuCaractere}\x00" + $"l\x01" + $"{bitCor}" + $"{linha.FilaMsgAlerta}\x02" + "\xA1" + $"{linha.FilaMsgDesc}          \x3S1\x0";

                        using Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        await socket.ConnectAsync(ip, 44818);
                        byte[] bytesToSend = Encoding.Latin1.GetBytes(messageHex);
                        await socket.SendAsync(bytesToSend, SocketFlags.None);

                        byte[] receiveBuffer = new byte[1024];
                        int bytesReceived = await socket.ReceiveAsync(receiveBuffer, SocketFlags.None);
                        string response = Encoding.Latin1.GetString(receiveBuffer, 0, bytesReceived);

                        if (!response.Contains("OK!"))
                        {
                            failedAlerts.Add($"Falha ao enviar alerta {linha.FilaMsgAlerta} para o IP {ip}: Painel não respondeu com 'OK!'");
                        }
                        else
                        {
                            successfulAlerts.Add($"Alerta {linha.FilaMsgAlerta} enviado com sucesso para o IP {ip}.");
                            await UpdateRespostaPainel(linha.FilaAreaCodigoEnvio, linha.FilaMsgDesc, linha.FilaMsgAlerta);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Trate a exceção individualmente para cada host
                        failedAlerts.Add($"Falha ao enviar alerta para o host {linha.FilaAreaCodigoEnvio}: {ex.Message}");
                    }
                }

                if (successfulAlerts.Count > 0)
                {
                    resultMessage += "200:" + string.Join(", ", successfulAlerts);
                    // Aqui você pode chamar o método para atualizar o estado dos alertas bem-sucedidos no painel
                }

                if (failedAlerts.Count > 0)
                {
                    resultMessage += "400:" + string.Join(", ", failedAlerts);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao enviar mensagem: {e.Message}");
                failedAlerts.Add($"Erro ao enviar mensagem: {e.Message}");
            }

            return resultMessage;
        }

        public async Task<string> PegaIp(int codigoArea) {

            TPainel var = await _ipRepository.SelecionarIpPort(codigoArea);

            return var.IpPainel;
        }
        
        public async Task<string> PegaCor(int codigoAlerta) {

            var var = await _ipRepository.SelecionarCorPainel(codigoAlerta);

            return var[0].DescricaoCor;
            //return null;
        } 
        
        public async Task<IEnumerable<FilaDTO>> PegaFila() {
            
            var Prio = await _ipRepository.SelecionarFilaPainel();
            return _mapper.Map<IEnumerable<FilaDTO>>(Prio);
        }

        public async Task<IEnumerable<FilaDTO>> PegaFilaGrupo(int grupo)
        {

            var Prio = await _ipRepository.SelecionarFilaPainelGrupo(grupo);
            return _mapper.Map<IEnumerable<FilaDTO>>(Prio);
        }

        public async Task<bool> CriaFila(List<AlertasModelNovo> request, string matricula)
        {
            AlertasEntitiesNovo[] novaInstancia = new AlertasEntitiesNovo[request.Count];

            for (int i = 0; i < request.Count; i++)
            {
                novaInstancia[i] = new AlertasEntitiesNovo
                {
                    Mensagem = request[i].Mensagem,
                    CodigoArea = request[i].CodigoArea,
                    Alerta = request[i].Alerta,
                    Prioridade = request[i].Prioridade,
                    Cor = request[i].Cor,
                    PainelEnvio = request[i].PainelEnvio
                };
            }

            // Envolva novaInstancia em uma lista antes de passar para FilaEnvio
            List<AlertasEntitiesNovo[]> listaDeInstancias = new List<AlertasEntitiesNovo[]> { novaInstancia };
            int result = await _filaRepository.FilaEnvio(listaDeInstancias, matricula);
            return result > 0;
        }

        public async Task<bool> CriaFilaUnica(List<AlertasModelNovo> request, string matricula)
        {
            List<AlertasEntitiesNovo> novaInstancia = new List<AlertasEntitiesNovo>();

            foreach (var alertaModel in request)
            {
                Console.WriteLine("Valor do count fila: " + request.Count);

                // Verifique se Alerta, Prioridade ou Cor estão vazios
                if (alertaModel.Alerta == null || alertaModel.Prioridade == null || string.IsNullOrEmpty(alertaModel.Cor))
                {
                    Console.WriteLine($"Alerta, Prioridade ou Cor estão vazios para o item {request.IndexOf(alertaModel)}");
                    continue; // Pula para a próxima iteração do loop
                }

                novaInstancia.Add(new AlertasEntitiesNovo
                {
                    Mensagem = alertaModel.Mensagem,
                    CodigoArea = alertaModel.CodigoArea,
                    Alerta = alertaModel.Alerta,
                    Prioridade = alertaModel.Prioridade,
                    Cor = alertaModel.Cor,
                    PainelEnvio = alertaModel.PainelEnvio
                });
            }

            // Verifica se há instâncias válidas para enviar
            if (novaInstancia.Count > 0)
            {
                int result = await _filaRepository.FilaEnvioUnico(novaInstancia, matricula);
                return result > 0;
            }
            else
            {
                Console.WriteLine("Todos os itens têm Alerta, Prioridade ou Cor vazios.");
                return false;
            }
        }

        public async Task UpdateDate()
        {
            // Verifique se a chave existe no cache
            if (_cache.TryGetValue("SuaChaveDeCache", out var cacheEntry))
            {
                // Se a entrada de cache existir, remova-a
                _cache.Remove("SuaChaveDeCache");

                // Log para fins de depuração
                // Console.WriteLine("A entrada do cache foi removida com sucesso.");
            }
            else
            {
                // Log para fins de depuração
                 Console.WriteLine("A chave não existe no cache.");
            }
        }

        public async Task UpdateRespostaPainel(int CodigoArea, string Mensagem, int CodigoAlerta)
        {
           await _filaRepository.UpdateRespostaPainel(CodigoArea, Mensagem, CodigoAlerta);
        }
    }
}
