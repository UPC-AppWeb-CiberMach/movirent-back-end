namespace Domain.IAM.Model.Commands
{
    public class DeleteUserCommand
    {
        public int id { get; private set; }

        public DeleteUserCommand(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID debe ser un número positivo.");
            }

            
        }
    }
}