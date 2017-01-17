using System;
namespace test.Models
{
    public class ExcerciseRepository : IDisposable
    {
        private TestContext context = new TestContext();
        private GenericRepository<Excercise> excerciseRepository;
       
        public GenericRepository<Excercise> ExcerciseRep
        {
            get
            {

                if (this.excerciseRepository == null)
                {
                    this.excerciseRepository = new GenericRepository<Excercise>(context);
                }
                return excerciseRepository;
            }
        }

       
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}