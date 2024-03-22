using PracticaEf;
using PracticaEf.Model;

namespace WebAPI.Service
{
    public class TaskService: ITaskService
    {
        TaskContext context;
        public TaskService(TaskContext dbcontext) 
        {
            this.context = dbcontext;
        }

        public IEnumerable<TaskModel> Get()
        {
            return context.Tasks;
        }

        public async Task Save(TaskModel task)
        {
            context.Add(task);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, TaskModel task)
        {
            var actualTask = context.Tasks.Find(id);

            if (actualTask != null)
            {
                actualTask.Title = task.Title;
                actualTask.Description = task.Description;
                actualTask.PriorityTask = task.PriorityTask;
                actualTask.Summary = task.Summary;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var actualTask = context.Tasks.Find(id);
            if (actualTask != null)
            {
                context.Remove(actualTask);
                await context.SaveChangesAsync();
            }
        }
    }


    public interface ITaskService
    {
        IEnumerable<TaskModel> Get();
        Task Save(TaskModel task);
        Task Update(Guid id, TaskModel task);
        Task Delete(Guid id);
    }
}

