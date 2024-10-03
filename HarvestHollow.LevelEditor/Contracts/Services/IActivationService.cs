namespace HarvestHollow.LevelEditor.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
