using GloriaEvents.Services.EventComponent.DbContexts;
using GloriaEvents.Services.EventRecords.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloriaEvents.Services.EventRecords.DbContexts
{
    public class EventsContext : DbContext
    {
        public EventsContext(DbContextOptions<EventsContext> options) : base(options)
        {

        }
        public DbSet<Categorys> Categorys { get; set; }
        public DbSet<Events> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityConfig());
            modelBuilder.ApplyConfiguration(new EventsEntityConfig());

            base.OnModelCreating(modelBuilder);

            var concertGuid = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA314}");
            var musicalGuid = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA315}");
            var playGuid = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA316}");

            modelBuilder.Entity<Categorys>().HasData(new Categorys
            {
                CategoryId = concertGuid,
                Name = "Concerts"
            });
            modelBuilder.Entity<Categorys>().HasData(new Categorys
            {
                CategoryId = musicalGuid,
                Name = "Musicals"
            });
            modelBuilder.Entity<Categorys>().HasData(new Categorys
            {
                CategoryId = playGuid,
                Name = "Plays"
            });

            modelBuilder.Entity<Events>().HasData(new Events
            {
                EventId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA317}"),
                Name = "John Egbert Live",
                Price = 65,
                Artist = "John Egbert",
                Date = DateTime.Now.AddMonths(6),
                Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                ImageUrl = "/img/banjo.jpg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Events>().HasData(new Events
            {
                EventId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA319}"),
                Name = "The State of Affairs: Michael Live!",
                Price = 85,
                Artist = "Michael Johnson",
                Date = DateTime.Now.AddMonths(9),
                Description = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                ImageUrl = "/img/michael.jpg",
                CategoryId = concertGuid
            });


            modelBuilder.Entity<Events>().HasData(new Events
            {
                EventId = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA318}"),
                Name = "To the Moon and Back",
                Price = 135,
                Artist = "Nick Sailor",
                Date = DateTime.Now.AddMonths(8),
                Description = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                ImageUrl = "/img/musical.jpg",
                CategoryId = musicalGuid
            });
        }

    }
}
