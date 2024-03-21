using Microsoft.EntityFrameworkCore;
using PracticaEf.Model;

namespace PracticaEf
{
    public class TaskContext: DbContext
    {
        public DbSet<TaskModel> Tasks { get; set;}
        public DbSet<Category> Categories { get; set;}

        public TaskContext(DbContextOptions<TaskContext> options): base(options) { }


        //modelo fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Category> listCategories = new List<Category>();
            listCategories.Add(new Category()
            {
                CategoryId = Guid.Parse("858beea5-49eb-4756-8592-be253188cf1f"),
                Name = "Actividades Pendientes",
                Description = "Actividades qu aun no se han realizado",
                Weight = 20
            });
            listCategories.Add(new Category()
            {
                CategoryId = Guid.Parse("858beea5-49eb-4756-8592-be253188cf12"),
                Name = "Actividades Personales",
                Description = "Actividades que personales de cualquier tipo",
                Weight = 50
            });



            //fluent api
            //creamos la configuracion para la entidad category
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("category");
                category.HasKey(p => p.CategoryId);

                category.Property(p => p.Name).IsRequired().HasMaxLength(150);
                category.Property(p => p.Description);
                category.Property(p => p.Weight);

                category.HasData(listCategories);// agrega la info
            });


            List<TaskModel> listTask = new List<TaskModel>();
            listTask.Add(new TaskModel()
            {
                TaskId = Guid.Parse("858beea5-49eb-4756-8592-be253188c500"),
                CategoryId = Guid.Parse("858beea5-49eb-4756-8592-be253188cf1f"),
                PriorityTask = Priority.High,
                Title = "Estudiar .net",
                Description = "Aprender mucho de .net",
                CreationDate = DateTime.Now,
                DeadLine = DateTime.Now.AddDays(7)
            }) ;
            listTask.Add(new TaskModel()
            {
                TaskId = Guid.Parse("858beea5-49eb-4756-8592-be253188c543"),
                CategoryId = Guid.Parse("858beea5-49eb-4756-8592-be253188cf12"),
                PriorityTask = Priority.Medium,
                Title = "Comprarme algo",
                Description = "Comprar en mercado libre",
                CreationDate = DateTime.Now,
                DeadLine = DateTime.Now.AddDays(7)
            });



            modelBuilder.Entity<TaskModel>(task =>
            {
                task.ToTable("task");
                task.HasKey(p => p.TaskId);

                task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
                //para especificar que existe una propiedad 'category' que tiene relacion con multiples tareas en la
                //tabla category el ienumerable 'Tasks'

                task.Property(p => p.Title).IsRequired().HasMaxLength(200);
                task.Property(p => p.Description);
                task.Property(p => p.PriorityTask);
                task.Property(p => p.CreationDate);
                task.Property(p => p.DeadLine);
                task.Ignore(p=>p.Summary);
                task.HasData(listTask);
            });
        }
    }
}
