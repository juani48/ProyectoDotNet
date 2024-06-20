using SGE.Aplicacion;
using SGE.Repositorio;
using SGE.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//servicion
builder.Services.AddSingleton<IServicioActualizacionEstado, ServicioActualizacionEstado>();
builder.Services.AddSingleton<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddSingleton<IServicioEncriptador, ServicioEncriptador>();

builder.Services.AddSingleton<ServicioSesionUsuario>(); //Servicio para gestion del usuario actual de la sesion

//casos de usos de expeidentes
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();

//casos de usos de tramites
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteListarPorEtiqueta>();
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultarPorId>();
builder.Services.AddTransient<CasoDeUsoTramiteListar>();

//casos de usos de usuarios
    //CRUD
    builder.Services.AddTransient<CasoDeUsoObtenerUsuario>();
    builder.Services.AddTransient<CasoDeUsoModificarUsuario>();
    builder.Services.AddTransient<CasoDeUsoListarUsuarios>();
    builder.Services.AddTransient<CasoDeUsoEliminarUsuario>();

    //Permisos
    builder.Services.AddTransient<CasoDeUsoAgregarPermiso>();
    builder.Services.AddTransient<CasoDeUsoEliminarPermiso>();

    //Sesion
    builder.Services.AddTransient<CasoDeUsoCerrarSesionActual>();
    builder.Services.AddTransient<CasoDeUsoIniciarSesion>();
    builder.Services.AddTransient<CasoDeUsoObtenerSesionActual>();
    builder.Services.AddTransient<CasoDeUsoRegistrarUsuario>();
    builder.Services.AddTransient<CasoDeUsoUsuarioActivo>();

    //Verificar
    builder.Services.AddTransient<CasoDeUsoVerificarIdentidad>();
    builder.Services.AddTransient<CasoDeUsoVerificarPermiso>();
    builder.Services.AddTransient<CasoDeUsoVerifivarPermisoAdministrador>();

//repositorios
builder.Services.AddSingleton<ITramiteRepositorio,RepositorioTramite>();
builder.Services.AddSingleton<IExpedienteRepositorio,RepositorioExpediente>();
builder.Services.AddSingleton<IUsuarioRepositorio, RepositorioUsuario>();

//Inicilizacion de los repositorios
RepositorioExpediente.Inicializar();
RepositorioTramite.Inicializar();
RepositorioUsuario.Inicializar();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
