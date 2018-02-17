namespace SoccerDataGenerator.Generators
{
    public interface IPersonGeneratorStrategy<TEntity>
    {
        TEntity CreatePerson(int totalRating, int mainFunction);

        void SetPersonalInformation(TEntity person);

        void SetPersonAttributes(TEntity person);

    }
}
