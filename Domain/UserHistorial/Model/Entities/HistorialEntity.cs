using Domain.Shared.Model.Entities;

namespace Domain.UserHistorial.Model.Entities;

public class HistorialEntity : ModelBase
{
    private int _scooterId;
    private int _userId;
    private DateTime _startTime;
    private DateTime _endTime;
    private int _price;
    private int _time;

    public int ScooterId
    {
        get => _scooterId;
        set
        {
            if (value <= 0)
                throw new ArgumentException("El ID del scooter debe ser mayor a 0.");
            _scooterId = value;
        }
    }

    public int UserId
    {
        get => _userId;
        set
        {
            if (value <= 0)
                throw new ArgumentException("El ID del usuario debe ser mayor a 0.");
            _userId = value;
        }
    }

    public DateTime StartTime
    {
        get => _startTime;
        set => _startTime = value;
    }

    public DateTime EndTime
    {
        get => _endTime;
        set
        {
            if (value <= _startTime)
                throw new ArgumentException("La hora de finalización debe ser posterior a la hora de inicio.");
            _endTime = value;
        }
    }

    public int Price
    {
        get => _price;
        set
        {
            if (value < 0)
                throw new ArgumentException("El precio no puede ser negativo.");
            _price = value;
        }
    }

    public int Time
    {
        get => _time;
        set
        {
            if (value <= 0)
                throw new ArgumentException("El tiempo debe ser mayor a 0.");
            _time = value;
        }
    }
}