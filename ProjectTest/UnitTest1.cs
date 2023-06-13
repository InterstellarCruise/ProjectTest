 namespace ProjectTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]

    





    public void bartime()
    {
        string date = "2023-03-15";
        string time = "12:15";
        BarLogic barLogic = new BarLogic();
        barLogic.timecheck(time,date,2.5);
        Assert.AreNotEqual(barLogic.timecheck(time,date,2.5),1);

    } 
    

    public void adreservationTest()
    {
        int showid = 1;
        int accountid = 1;
        List<int> chairids =new List<int>{23,24} ;
        double amount = 16;
        ReservationsLogic reservationsLogic = new ReservationsLogic();
        reservationsLogic.AddReservation(showid,accountid,chairids,amount);
        List<ReservationModel> Reservations = ReservationsAccess.LoadAll();
        int theid = Reservations.Count();
        ReservationModel reservation = new ReservationModel(theid,showid,accountid,chairids,amount);
        Assert.AreEqual(reservation, Reservations[-1]);
        Assert.AreNotEqual(reservation, Reservations[0]);
    }
    public void GetByIdTTest()
    {
        BaseLogic<ShowModel> baseLogic1 = new ShowsLogic();
        BaseLogic<ReservationModel> baselogic2 = new ReservationsLogic();
        var theshows = ShowsAccess.LoadAll();
        var thereserves = ReservationsAccess.LoadAll();
        Assert.AreEqual(baseLogic1.GetById(1),theshows[0] );
        Assert.AreNotEqual(baseLogic1.GetById(1),theshows[1] );
        Assert.AreEqual(baselogic2.GetById(1),thereserves[0] );
        Assert.AreNotEqual(baselogic2.GetById(1),thereserves[1] );

    }
    public void GetByshowIdTest()
    {
        ReservationsLogic reservelogic = new ReservationsLogic();
        var thereserves = ReservationsAccess.LoadAll();
        Assert.AreEqual(reservelogic.GetByShowId(1),thereserves[0] );
        Assert.AreNotEqual(reservelogic.GetByShowId(3),thereserves[1]);
    }

    public void Getlastid()
    {
        ShowsLogic showsLogic = new ShowsLogic();
        var theshows = ShowsAccess.LoadAll();
        int LastID = ShowsLogic.LastID();
        Assert.AreEqual(LastID,theshows[-1] );
        Assert.AreNotEqual(LastID ,theshows[1]);

    }
    public void GetByfilmIdTest()
    {
        ShowsLogic showsLogic = new ShowsLogic();
        var theshows = ShowsAccess.LoadAll();
        Assert.AreEqual(showsLogic.GetByFilmId(1),theshows[0] );
        Assert.AreNotEqual(showsLogic.GetByFilmId(3),theshows[1]);

    }
    public void GetByCol()
    {
        ChairLogic chairLogic = new ChairLogic();
        var chairs = ChairsAccess.LoadAll();
        Assert.AreEqual(chairLogic.GetByCol(1),chairs[0] );
        Assert.AreNotEqual(chairLogic.GetByCol(1),chairs[1] );
        

    }


}
