using PrivateNotes.Repositories;
using PrivateNotes.Services;

namespace PrivateNotes;

public static class DependencyExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INoteServices, NoteServices>();
        services.AddScoped<IUserServices, UserServices>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<INoteRepository, NoteRepository>();
        return services;
    }
}