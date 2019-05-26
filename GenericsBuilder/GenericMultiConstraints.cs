namespace GenericsBuilder
{
    // Generic class with 'conversion type' constraints
    class GenericMultiConstraints<TState> where TState: AccountFrozen, IAccountState
    {
        public void Deposit()
        {

        }
    }

    
    class AccountFrozen{}
    interface IAccountState{}

    class Account1: AccountFrozen, IAccountState
    {

    }
    
    class Account2: AccountFrozen // Not implimenting IAccountState
    {

    }
    
    
    


}
