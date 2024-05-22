using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Paineis.Application.Interfaces;
using Paineis.Application.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Paineis.Infra.Ioc
{
    public class SocketServerPainelHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private CancellationTokenSource _cts;
        private Task _executingTask;

        public SocketServerPainelHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _cts = new CancellationTokenSource();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            

            // Inicie uma nova tarefa para executar o serviço em um loop infinito
            Task.Run(async () =>
            {

                using var scope = _serviceProvider.CreateScope();
                var socketServerPainelService = scope.ServiceProvider.GetRequiredService<ISocketServerPainelService>();

                await socketServerPainelService.UpdateDate();

                while (!cancellationToken.IsCancellationRequested)
                {
                    await socketServerPainelService.StartSendingMessages(cancellationToken);  
                }

                
            });

            return Task.CompletedTask;
        }


        public async Task RestartAsync(CancellationToken cancellationToken)
        {
            if (_executingTask != null && !_executingTask.IsCompleted)
            {
                _cts.Cancel();
                await StopAsync(cancellationToken);
            }
            _cts = new CancellationTokenSource();
            await StartAsync(cancellationToken);
        }


        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_executingTask != null)
            {
                _cts.Cancel();
                await _executingTask;
            }
        }

    }
}