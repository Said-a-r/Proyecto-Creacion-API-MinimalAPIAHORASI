using proyectoAPICatalogoW.Models; 
using Microsoft.EntityFrameworkCore; 

namespace proyectoAPICatalogoW.Data; 

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Jugador> Jugadores => Set<Jugador>();
    public DbSet<Mision> Misiones => Set<Mision>();
    public DbSet<CardPersonaje> Cartas => Set<CardPersonaje>();
    public DbSet<Personaje> Personajes => Set<Personaje>();
    public DbSet<Evento> Eventos => Set<Evento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Jugador>(e =>
        {
            e.Property(j => j.Nombre).IsRequired().HasMaxLength(100);
            e.Property(j => j.Puntaje).HasDefaultValue(0); 
        });

        modelBuilder.Entity<Mision>(e =>
        {
            e.Property(m => m.Nombre).IsRequired().HasMaxLength(100);
        });
        
        modelBuilder.Entity<Mision>().HasData(
            new Mision { Id = 1, Nombre = "Prueba Fácil", PoderRequerido = 10000, PuntosRecompensa = 50 },
            new Mision { Id = 2, Nombre = "Prueba Difícil", PoderRequerido = 20000, PuntosRecompensa = 200 }
        );

        modelBuilder.Entity<Personaje>(e =>
        {
            e.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
            e.Property(p => p.Especie).HasMaxLength(100);
            e.Property(p => p.Faccion).HasMaxLength(50);
            e.Property(p => p.Afiliacion).HasMaxLength(100);
            e.Property(p => p.Estado).HasMaxLength(50);
        });

        modelBuilder.Entity<Evento>(e =>
        {
            e.Property(ev => ev.Nombre).IsRequired().HasMaxLength(150);
            e.Property(ev => ev.Ubicacion).HasMaxLength(150);
            e.Property(ev => ev.Descripcion).HasMaxLength(500);
            e.Property(ev => ev.Resultado).HasMaxLength(200);
        });

        modelBuilder.Entity<CardPersonaje>(e =>
        {
            e.Property(c => c.HabilidadEspecial).HasMaxLength(200);
            e.Property(c => c.Arma).HasMaxLength(100);
            e.Property(c => c.NivelPeligrosidad).HasMaxLength(50);
            e.Property(c => c.ImagenUrl).HasMaxLength(500);
            
            e.HasOne(c => c.jugador)
                .WithMany(j => j.Cartas)
                .HasForeignKey(c => c.JugadorId)
                .OnDelete(DeleteBehavior.SetNull); 

            e.HasOne(c => c.personaje)
                .WithMany()
                .HasForeignKey(c => c.PersonajeId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}