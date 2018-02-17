using YouthGenerator.Data;

namespace YouthGenerator.Engine
{
    public interface IPersonGeneratorEngineStrategy<TEntity>
    {
        TEntity CreatePerson(int totalRating, int mainFunction);

        void SetPersonPersonalInformation(TEntity person);

        void SetPersonAttributes(TEntity person);

    }
}
