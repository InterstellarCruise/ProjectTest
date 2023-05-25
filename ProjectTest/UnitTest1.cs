namespace ProjectTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void CheckLastIDTest()
    {

        int id = 99999;
        List<string> genres = new List<string>();
        genres.Add("Horror");
        FilmModel film = new FilmModel(id, "Unit", "test", 0, 2.5, genres);
        FilmsLogic filmlogic = new FilmsLogic();
        filmlogic.UpdateList(film);
        List<FilmModel> _films;
        _films = FilmsAccess.LoadAll();
        int last = _films[_films.Count - 1].Id;
        Assert.AreEqual(id, last);
    }
    public void CheckAllFilmsTest()
    {

    }
    public void CheckReservationsByAccountTest()
    {

    }
    public void CheckDeleteReservationTest()
    {

    }
    public void CheckMoviesByDateTest()
    {

    }
    public void CheckChooseShowTest()
    {

    }
    public void CheckShowsByDateTest()
    {

    }
    public void CheckValidShowTimeTest()
    {

    }
}
