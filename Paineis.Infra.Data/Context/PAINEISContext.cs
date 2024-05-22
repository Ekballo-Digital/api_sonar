using Microsoft.EntityFrameworkCore;

namespace Paineis.Domain.Entities
{
    public partial class PAINEISContext : DbContext
    {
        public PAINEISContext()
        {
        }

        public PAINEISContext(DbContextOptions<PAINEISContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAlertum> TAlerta { get; set; } = null!;
        public virtual DbSet<TArea> TAreas { get; set; } = null!;
        public virtual DbSet<TCor> TCors { get; set; } = null!;
        public virtual DbSet<TEstado> TEstados { get; set; } = null!;
        public virtual DbSet<TFuncao> TFuncaos { get; set; } = null!;
        public virtual DbSet<TFuncaoMenu> TFuncaoMenus { get; set; } = null!;
        public virtual DbSet<TGrupoAd> TGrupoAds { get; set; } = null!;
        public virtual DbSet<TLogEnvioMsg> TLogEnvioMsgs { get; set; } = null!;
        public virtual DbSet<TLogOperacao> TLogOperacaos { get; set; } = null!;
        public virtual DbSet<TMatriz> TMatrizs { get; set; } = null!;
        public virtual DbSet<TMenu> TMenus { get; set; } = null!;
        public virtual DbSet<TMenuPerfil> TMenuPerfils { get; set; } = null!;
        public virtual DbSet<TPainel> TPainels { get; set; } = null!;
        public virtual DbSet<TPerfil> TPerfils { get; set; } = null!;
        public virtual DbSet<TPrioridade> TPrioridades { get; set; } = null!;
        public virtual DbSet<TFila> TFilas { get; set; } = null!;
        public virtual DbSet<InfoLogin> InfoLogins { get; set; } = null!;
        public virtual DbSet<GenerateMenu> GenerateMenus { get; set; } = null!;
        public virtual DbSet<GeneratePainel> GeneratePaineis { get; set; } = null!;
        public virtual DbSet<AuthDoubleAd> AuthDoubleAds { get; set; } = null!;
        public virtual DbSet<FuncaoMenuGenerate> FuncaoMenuGenerates { get; set; } = null!;
        public virtual DbSet<PainelUsoEntities> PainelUsos { get; set; } = null!;
        public virtual DbSet<GerarSilgasTabelaMatrizEntities> GerarSilgasTabelaMatrizes { get; set; } = null!;
        public virtual DbSet<TbaGerarSiglaCD> TbaGerarSiglaCDs { get; set; } = null!;
        public virtual DbSet<GerarEstadosTabelaMatrizEntities> GerarEstadosTabelaMatrizes { get; set; } = null!;
        public virtual DbSet<GerarAlertasTabelaMatrizEntities> GerarAlertasTabelaMatrizes { get; set; } = null!;
        public virtual DbSet<PegaEstado> PegaEstados { get; set; } = null!;
        public virtual DbSet<NivelAlerta> NivelAlertas { get; set; } = null!;
        public virtual DbSet<PegaPrioridade> PegaPrioridades { get; set; } = null!;
        public virtual DbSet<GerarCoresEntities> GerarCores { get; set; } = null!;
        public virtual DbSet<GerarAreasEntities> GerarAreas { get; set; } = null!;
        public virtual DbSet<GerarPerfilEntities> GerarPerfil { get; set; } = null!;
        public virtual DbSet<GerarMenuEntities> GerarMenus { get; set; } = null!;
        public virtual DbSet<GerarEstadoEntities> GerarEstados { get; set; } = null!;
        public virtual DbSet<TMatrizUpdate> TMatrizUpdates { get; set; } = null!;
        public virtual DbSet<SelectNomeEstado> SelectNomeEstados { get; set; } = null!;
        public virtual DbSet<SelectNomeArea> SelectNomeAreas { get; set; } = null!;
        public virtual DbSet<SelectNomeAlerta> SelectNomeAlertas { get; set; } = null!;
        public virtual DbSet<SelectNomePrioridade> SelectNomePrioridades { get; set; } = null!;
        public virtual DbSet<ValPainel> ValPainels { get; set; } = null!;
        public virtual DbSet<ValidaUrlsWeb> ValidaUrlsWebs { get; set; } = null!;
        public virtual DbSet<AlertasEntities> AlertasEntitiess { get; set; } = null!;
        public virtual DbSet<TCorSocket> TCorSockets { get; set; } = null!;
        public virtual DbSet<AlertasEntitiesNovo> AlertasEntitiesNovos { get; set; } = null!;
        public virtual DbSet<GruposMsg> GruposMsgs { get; set; } = null!;
        public virtual DbSet<NivelAlerta2> NivelAlertas2 { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SQL47CL2\\INST47;Database=HL2403;User Id=ADMCTE;Password=8:zth<2(");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAlertum>(entity =>
            {
                entity.HasKey(e => e.CodigoAlerta);

                entity.ToTable("T_ALERTA");

                entity.Property(e => e.CodigoAlerta)
                    .ValueGeneratedOnAdd() // Alteração para ValueGeneratedOnAdd
                    .HasColumnName("CODIGO_ALERTA");

                entity.Property(e => e.CodigoCor).HasColumnName("CODIGO_COR");

                entity.Property(e => e.DescricaoAlerta)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO_ALERTA");

                entity.Property(e => e.NivelAlerta).HasColumnName("NIVEL_ALERTA");

                entity.HasOne(d => d.CodigoCorNavigation)
                    .WithMany(p => p.TAlerta)
                    .HasForeignKey(d => d.CodigoCor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("T_ALERTA_fk0");

                entity.HasIndex(e => e.DescricaoAlerta).IsUnique();
            });

            modelBuilder.Entity<TArea>(entity =>
            {
                entity.HasKey(e => e.CodigoArea);

                entity.ToTable("T_AREA");

                entity.Property(e => e.CodigoArea)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CODIGO_AREA");

                entity.Property(e => e.NomeArea)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NOME_AREA");

                entity.Property(e => e.SiglaArea)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SIGLA_AREA");

                entity.Property(e => e.TipoArea)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_AREA");
            });

            modelBuilder.Entity<TCor>(entity =>
            {
                entity.HasKey(e => e.CodigoCor);

                entity.ToTable("T_COR");

                entity.Property(e => e.CodigoCor)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CODIGO_COR");

                entity.Property(e => e.DescricaoCor)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO_COR");

                entity.Property(e => e.HexaCor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HEXA_COR");

                entity.Property(e => e.HexaCorRed)
                     .HasMaxLength(50)
                     .IsUnicode(false)
                     .HasColumnName("HEXA_COR_RED");

                entity.Property(e => e.HexaCorGreen)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HEXA_COR_GREEN");

                entity.Property(e => e.HexaCorBlue)
                   .HasMaxLength(50)
                   .IsUnicode(false)
                   .HasColumnName("HEXA_COR_BLUE");
            });

            modelBuilder.Entity<TEstado>(entity =>
            {
                entity.HasKey(e => e.CodigoEstado);

                entity.ToTable("T_ESTADO");

                entity.Property(e => e.CodigoEstado)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CODIGO_ESTADO");

                entity.Property(e => e.CodigoAreaEstado).HasColumnName("CODIGO_AREA_ESTADO");

                entity.Property(e => e.DescricaoEstado)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO_ESTADO");

                entity.Property(e => e.TipoEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_ESTADO");

                entity.HasOne(d => d.CodigoAreaEstadoNavigation)
                    .WithMany(p => p.TEstados)
                    .HasForeignKey(d => d.CodigoAreaEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("T_ESTADO_fk0");
            });

            modelBuilder.Entity<TFuncao>(entity =>
            {
                entity.HasKey(e => e.CodigoFuncao);

                entity.ToTable("T_FUNCAO");

                entity.Property(e => e.CodigoFuncao)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CODIGO_FUNCAO");

                entity.Property(e => e.DescricaoFuncao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO_FUNCAO");

                entity.Property(e => e.UrlFuncao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("URL_FUNCAO");

                entity.Property(e => e.IconSvg)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ICON_SVG");
            });

            modelBuilder.Entity<TFuncaoMenu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_FUNCAO_MENU");

                entity.Property(e => e.CodigoFuncao).HasColumnName("CODIGO_FUNCAO");

                entity.Property(e => e.CodigoMenu).HasColumnName("CODIGO_MENU");

                entity.HasOne(d => d.CodigoFuncaoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoFuncao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("T_FUNCAO_MENU_fk1");

                entity.HasOne(d => d.CodigoMenuNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_FUNCAO_MENU_T_MENU");
            });

            modelBuilder.Entity<TGrupoAd>(entity =>
            {
                entity.HasKey(e => e.CodigoGrupoAd);

                entity.ToTable("T_GRUPO_AD");

                entity.Property(e => e.CodigoAreaGrupoAd).HasColumnName("CODIGO_AREA_GRUPO_AD");

                entity.Property(e => e.CodigoGrupoAd)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CODIGO_GRUPO_AD");

                entity.Property(e => e.CodigoPerfil).HasColumnName("CODIGO_PERFIL");

                entity.Property(e => e.NomeGrupoAd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NOME_GRUPO_AD");
                /*
                entity.HasOne(d => d.CodigoAreaGrupoAdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoAreaGrupoAd)
                    .HasConstraintName("FK_T_GRUPO_AD_T_AREA");

                entity.HasOne(d => d.CodigoPerfilNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoPerfil)
                    .HasConstraintName("FK_T_GRUPO_AD_T_PERFIL");*/
            });

            modelBuilder.Entity<TLogEnvioMsg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_LOG_ENVIO_MSG");

                entity.Property(e => e.CodigoAreaMsg).HasColumnName("CODIGO_AREA_MSG");

                entity.Property(e => e.CodigoEstadoMsg).HasColumnName("CODIGO_ESTADO_MSG");

                entity.Property(e => e.CodigoStatusEnvioMsg).HasColumnName("CODIGO_STATUS_ENVIO_MSG");

                entity.Property(e => e.DataMsg)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_MSG");

                entity.Property(e => e.DescricaoMsg)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO_MSG");

                entity.Property(e => e.MatriculaUsuarioMsg)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MATRICULA_USUARIO_MSG");
            });

            modelBuilder.Entity<TLogOperacao>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_LOG_OPERACAO");

                entity.Property(e => e.CodigoFuncaoLogOperacao).HasColumnName("CODIGO_FUNCAO_LOG_OPERACAO");

                entity.Property(e => e.CodigoPerfilLogOperacao).HasColumnName("CODIGO_PERFIL_LOG_OPERACAO");

                entity.Property(e => e.DataLogOperacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_LOG_OPERACAO");

                entity.Property(e => e.DescricaoLogOperacao)
                    .HasColumnType("text")
                    .HasColumnName("DESCRICAO_LOG_OPERACAO");

                entity.Property(e => e.MatriculaUsuarioLogOperacao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MATRICULA_USUARIO_LOG_OPERACAO");

                entity.Property(e => e.TipoQueryLogOperacao)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_QUERY_LOG_OPERACAO");
            });

            modelBuilder.Entity<TMatriz>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_MATRIZ");

                entity.Property(e => e.CodigoAlerta).HasColumnName("CODIGO_ALERTA");

                entity.Property(e => e.CodigoArea).HasColumnName("CODIGO_AREA");

                entity.Property(e => e.CodigoEstado).HasColumnName("CODIGO_ESTADO");

                entity.Property(e => e.CodigoPrioridade).HasColumnName("CODIGO_PRIORIDADE");

                entity.HasOne(d => d.CodigoAlertaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoAlerta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_MATRIZ_T_ALERTA");

                entity.HasOne(d => d.CodigoAreaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_MATRIZ_T_AREA");

                entity.HasOne(d => d.CodigoEstadoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_MATRIZ_T_ESTADO");

                entity.HasOne(d => d.CodigoPrioridadeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoPrioridade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_MATRIZ_T_PRIORIDADE");
            });

            modelBuilder.Entity<TMenu>(entity =>
            {
                entity.HasKey(e => e.CodigoMenu);

                entity.ToTable("T_MENU");

                entity.Property(e => e.CodigoMenu)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CODIGO_MENU");

                entity.Property(e => e.NomeMenu)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NOME_MENU");

                entity.Property(e => e.UrlMenu)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("URL_MENU");
            });

            modelBuilder.Entity<TMenuPerfil>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_MENU_PERFIL");

                entity.Property(e => e.CodigoMenu).HasColumnName("CODIGO_MENU");

                entity.Property(e => e.CodigoPerfil).HasColumnName("CODIGO_PERFIL");

                entity.HasOne(d => d.CodigoMenuNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_MENU_PERFIL_T_MENU");

                entity.HasOne(d => d.CodigoPerfilNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("T_MENU_PERFIL_fk0");
            });

            modelBuilder.Entity<TPainel>(entity =>
            {
                entity.HasKey(e => e.CodigoPainel);

                entity.ToTable("T_PAINEL");

                entity.Property(e => e.CodigoPainel)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CODIGO_PAINEL");

                entity.Property(e => e.CodigoArea).HasColumnName("CODIGO_AREA");

                entity.Property(e => e.IpPainel)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IP_PAINEL");

                entity.Property(e => e.PortaPainel).HasColumnName("PORTA_PAINEL");

                entity.Property(e => e.StatusPainel).HasColumnName("STATUS_PAINEL");

                entity.HasOne(d => d.CodigoAreaNavigation)
                    .WithMany(p => p.TPainels)
                    .HasForeignKey(d => d.CodigoArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("T_PAINEL_fk0");
            });

            modelBuilder.Entity<TPerfil>(entity =>
            {
                entity.HasKey(e => e.CodigoPerfil);

                entity.ToTable("T_PERFIL");

                entity.Property(e => e.CodigoPerfil)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CODIGO_PERFIL");

                entity.Property(e => e.NomePerfil)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NOME_PERFIL");
            });

            modelBuilder.Entity<TPrioridade>(entity =>
            {
                entity.HasKey(e => e.CodigoPrioridade);

                entity.ToTable("T_PRIORIDADE");

                entity.Property(e => e.CodigoPrioridade)
                    .ValueGeneratedNever()
                    .HasColumnName("CODIGO_PRIORIDADE");

                entity.Property(e => e.NomePrioridade)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NOME_PRIORIDADE");
            });

            modelBuilder.Entity<TFila>(entity =>
            {
                entity.HasNoKey();  // Indica que esta entidade não tem uma chave primária
                entity.ToTable("T_FILA");

                // Mapeamento das colunas
                entity.Property(e => e.CodigoPainel).HasColumnName("CODIGO_PAINEL");
                entity.Property(e => e.CodigoFilaMsg).HasColumnName("CODIGO_FILA_MSG");
                entity.Property(e => e.FilaMsgAlerta).HasColumnName("FILA_MSG_ALERTA");
                entity.Property(e => e.FilaMsgPrioridade).HasColumnName("FILA_MSG_PRIORIDADE");
                entity.Property(e => e.FilaMsgDesc).HasColumnType("text").HasColumnName("FILA_MSG_DESC");
                entity.Property(e => e.FilaAreaCodigoEnvio).HasColumnName("FILA_AREA_CODIGO_ENVIO");
                entity.Property(e => e.FilaEnvioCodigo).HasColumnName("FILA_ENVIO_CODIGO");
                entity.Property(e => e.Matricula).HasColumnName("MATRICULA");
                entity.Property(e => e.PainelEnvio).HasColumnName("PAINEL_ENVIO");
            });

            modelBuilder.Entity<InfoLogin>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<GenerateMenu>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<GeneratePainel>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<AuthDoubleAd>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<FuncaoMenuGenerate>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<PainelUsoEntities>(entity =>
            {
                entity.HasNoKey();
            });
            
            modelBuilder.Entity<GerarSilgasTabelaMatrizEntities>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<TbaGerarSiglaCD>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GerarEstadosTabelaMatrizEntities>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GerarAlertasTabelaMatrizEntities>(entity =>
            {
                entity.HasNoKey();
            });
            
            modelBuilder.Entity<PegaEstado>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<NivelAlerta>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<PegaPrioridade>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GerarCoresEntities>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GerarAreasEntities>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GerarPerfilEntities>(entity =>
            {
                entity.HasNoKey();
            }); 
            modelBuilder.Entity<GerarMenuEntities>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GerarEstadoEntities>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<TMatrizUpdate>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<SelectNomeEstado>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<SelectNomeArea>(entity =>
            {
                entity.HasNoKey();
            }); 
            modelBuilder.Entity<SelectNomeAlerta>(entity =>
            {
                entity.HasNoKey();
            }); 
            modelBuilder.Entity<SelectNomePrioridade>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<ValPainel>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<ValidaUrlsWeb>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<AlertasEntities>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<TCorSocket>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<AlertasEntitiesNovo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GruposMsg>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<NivelAlerta2>(entity =>
            {
                entity.HasNoKey();
            });
          

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
