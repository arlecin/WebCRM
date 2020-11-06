using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebCRM.DataAccess
{
	public class ModelContext : DbContext
	{
		public DbSet<Founder> Founders { get; set; }

		public DbSet<Client> Clients { get; set; }

		public ModelContext() :base()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ComplexArchitectureDB;Trusted_Connection=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<FounderClient>()
				.HasKey(founderClient => new { founderClient.ClientId, founderClient.FounderId });

			modelBuilder.Entity<FounderClient>()
				.HasOne(founderClient => founderClient.Client)
				.WithMany(client => client.FounderClients)
				.HasForeignKey(founderClient => founderClient.ClientId);

			modelBuilder.Entity<FounderClient>()
			   .HasOne(founderClient => founderClient.Founder)
				.WithMany(client => client.FounderClients)
				.HasForeignKey(founderClient => founderClient.FounderId);
		}
	}
}
