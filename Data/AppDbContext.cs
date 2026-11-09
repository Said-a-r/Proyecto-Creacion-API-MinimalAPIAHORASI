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
            e.Property(j => j.PuntajeCifrado).IsRequired(); 
            e.Property(j => j.PasswordHash).IsRequired();
        });

        modelBuilder.Entity<Mision>(e =>
        {
            e.Property(m => m.Nombre).IsRequired().HasMaxLength(100);
        });
        
        modelBuilder.Entity<Mision>().HasData(
            new Mision { Id = 1, Nombre = "Facil", PoderRequerido = 10000, PuntosRecompensa = 50 },
            new Mision { Id = 2, Nombre = "Dificil", PoderRequerido = 20000, PuntosRecompensa = 200 }
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

        modelBuilder.Entity<Personaje>().HasData(
            new Personaje { Id = 1, Nombre = "Darth Vader", Especie = "Humano", Faccion = "Imperio", Afiliacion = "Imperio", Estado = "vivo" },
            new Personaje { Id = 2, Nombre = "Luke Skywalker", Especie = "Humano", Faccion = "Rebelde", Afiliacion = "Alianza Rebelde", Estado = "vivo" },
            new Personaje { Id = 3, Nombre = "Han Solo", Especie = "Humano", Faccion = "Rebelde", Afiliacion = "Alianza Rebelde", Estado = "vivo" },
            new Personaje { Id = 4, Nombre = "Yoda", Especie = "Desconocida", Faccion = "Rebelde", Afiliacion = "Orden Jedi", Estado = "vivo" },
            new Personaje { Id = 5, Nombre = "Emperador Palpatine", Especie = "Humano", Faccion = "Imperio", Afiliacion = "Imperio", Estado = "vivo" }
        );

        modelBuilder.Entity<CardPersonaje>().HasData(
            new CardPersonaje { Id = 1, PersonajeId = 1, Poder = 9000, HabilidadEspecial = "Estrangulamiento", Arma = "Sable de luz", NivelPeligrosidad = "Alto", ImagenUrl = "" },
            new CardPersonaje { Id = 2, PersonajeId = 2, Poder = 8500, HabilidadEspecial = "Telequinesis", Arma = "Sable de luz", NivelPeligrosidad = "Alto", ImagenUrl = "" },
            new CardPersonaje { Id = 3, PersonajeId = 3, Poder = 5000, HabilidadEspecial = "Puntería", Arma = "Bláster", NivelPeligrosidad = "Medio", ImagenUrl = "" },
            new CardPersonaje { Id = 4, PersonajeId = 4, Poder = 9500, HabilidadEspecial = "Fuerza Maestra", Arma = "Sable de luz", NivelPeligrosidad = "Alto", ImagenUrl = "" },
            new CardPersonaje { Id = 5, PersonajeId = 5, Poder = 9800, HabilidadEspecial = "Rayos", Arma = "Sable de luz", NivelPeligrosidad = "Alto", ImagenUrl = "" },
            new CardPersonaje { Id = 6, PersonajeId = 1, Poder = 8000, HabilidadEspecial = "Fuerza Oscura", Arma = "Sable de luz", NivelPeligrosidad = "Medio", ImagenUrl = "" },
            new CardPersonaje { Id = 7, PersonajeId = 2, Poder = 7800, HabilidadEspecial = "Maestría Jedi", Arma = "Sable de luz", NivelPeligrosidad = "Medio", ImagenUrl = "" },
            new CardPersonaje { Id = 8, PersonajeId = 3, Poder = 4500, HabilidadEspecial = "Disparo Rápido", Arma = "Bláster", NivelPeligrosidad = "Bajo", ImagenUrl = "" },
            new CardPersonaje { Id = 9, PersonajeId = 4, Poder = 9200, HabilidadEspecial = "Salto Alto", Arma = "Sable de luz", NivelPeligrosidad = "Alto", ImagenUrl = "" },
            new CardPersonaje { Id = 10, PersonajeId = 5, Poder = 8900, HabilidadEspecial = "Manipulación", Arma = "Sable de luz", NivelPeligrosidad = "Medio", ImagenUrl = "" }
        );
    }
}