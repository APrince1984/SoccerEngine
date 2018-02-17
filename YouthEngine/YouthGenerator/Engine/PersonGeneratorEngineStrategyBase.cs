namespace YouthGenerator.Engine
{
    public abstract class PersonGeneratorEngineStrategyBase<TEntity> : IPersonGeneratorEngineStrategy<TEntity> where TEntity : class , new()
    {
        public abstract TEntity CreatePerson(int totalRating, int mainFunction);

        public abstract void SetPersonAttributes(TEntity person);

        public abstract void SetPersonPersonalInformation(TEntity person);
    }
}
