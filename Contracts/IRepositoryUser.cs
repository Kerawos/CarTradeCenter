using CarTradeCenter.Data.Models;


namespace CarTradeCenter.Contracts
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        bool Create(User entity);
        bool Update(User entity);
        bool PromoteToAdmin(User entity);
        bool ConfirmPhoneNumber(User entity);
        bool ConfirmEmail(User entity);
        bool BidVehicle(User entity, Vehicle vehicle, double amount);
    }
}
