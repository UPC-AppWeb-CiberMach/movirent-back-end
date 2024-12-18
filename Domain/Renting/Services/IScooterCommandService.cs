﻿using Domain.Renting.Model.Commands;
using Domain.Scooter.Model.Commands;

namespace Domain.Renting.Services;

public interface IScooterCommandService
{
    Task<Guid> Handle(CreateScooterCommand command);
    Task<bool> Handle(UpdateScooterCommand command);
    Task<bool> Handle(DeleteScooterCommand command);
}