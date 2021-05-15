using System.Collections.Generic;
using System.Reflection;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {

        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options): base(options) {

        }
        // public DevFreelaDbContext(){
        //     Projects = new List<Project>(){ 
        //         new Project("Meu Projeto Asp.net Core","Minha Descricao do Projeto",1,1,10000 ),
        //         new Project("Meu Projeto Spring Boot","Minha Descricao do Projeto",1,1,20000 ),
        //         new Project("Meu Projeto Golang","Minha Descricao do Projeto",1,1,30000 )
        //         };

        //         Users = new List<User>(){
        //             new User("fulano","fulano@gmail.com",new System.DateTime(1992,1,1)),
        //             new User("ciclano","ciclano@gmail.com",new System.DateTime(1992,1,2)),
        //             new User("beltrano","beltrano@gmail.com",new System.DateTime(1992,1,3)),
        //         };

        //         Skills = new List<Skill>(){
        //             new Skill(".NET CORE"),
        //             new Skill("C#"),
        //             new Skill("SQL")
        //         };
        // }
        public DbSet<Project> Projects {get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet<Skill> Skills { get; set;}
        public DbSet<UserSkill> userSkill { get; set;}
        public DbSet<ProjectComment> ProjectComments { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){

           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity<Skill>()
            .HasKey( p => p.Id);

            modelBuilder.Entity<UserSkill>()
            .HasKey( p => p.Id);
        }
    }
}