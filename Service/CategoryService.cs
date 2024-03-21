using PracticaEf;
using PracticaEf.Model;

namespace WebAPI.Service
{
    public class CategoryService:ICategoryService
    {
        TaskContext context;

        public CategoryService(TaskContext dbcontext)
        {
            this.context = dbcontext;
        }

        public IEnumerable<Category>Get() 
        {
            return context.Categories;
        }

        public async Task Save(Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id,Category category)
        {
            var actualCategory = context.Categories.Find(id);
            if (actualCategory != null)
            {
                actualCategory.Name = category.Name;
                actualCategory.Description = category.Description;
                actualCategory.Weight = category.Weight;
                
                await context.SaveChangesAsync();
            }
           
        }


        public async Task Delete(Guid id)
        {
            var actualCategory = context.Categories.Find(id);
            if (actualCategory != null)
            {
                context.Remove(actualCategory);

                await context.SaveChangesAsync();
            }

        }
    }
    
    
    
    
    
    
    
    
    
    //interfaz para implementar los servicios
    public interface ICategoryService
    {
        IEnumerable<Category> Get();
        Task Save(Category category);
        Task Update(Guid id,Category category);
        Task Delete(Guid id);
    }
}






