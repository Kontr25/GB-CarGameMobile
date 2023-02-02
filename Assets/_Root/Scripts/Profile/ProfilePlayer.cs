using Features.Inventory;
using Game.Car;
using Tool;

namespace Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly CarModel CurrentCar;
        public readonly InventoryModel Inventory;


        public ProfilePlayer(float speedCar, GameState initialState, float jumpHeight, 
            float visibilityRange, float endurance) : this(speedCar, jumpHeight, visibilityRange, endurance)
        {
            CurrentState.Value = initialState;
        }

        public ProfilePlayer(float speedCar, float jumpHeight, float visibilityRange, float endurance)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new CarModel(speedCar, jumpHeight, visibilityRange, endurance);
            Inventory = new InventoryModel();
        }
    }
}
