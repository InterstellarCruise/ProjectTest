namespace ProjectTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void CheckAccountEmailTest()
    {
        AccountsLogic accounts = new AccountsLogic();
        string validemail = "test@";
        string validpassword = "test";
        string fullname = "test test";
        accounts.NewAcc(validemail, validpassword, fullname);

        string invalidemail = "testttt@";
        Assert.IsTrue(accounts.CheckEmail(validemail));
        Assert.IsFalse(accounts.CheckEmail(invalidemail));
        accounts.RemoveAcc(validemail);
    }
    [TestMethod]
    public void CheckLoginTest()
    {
        AccountsLogic accounts = new AccountsLogic();
        string email = "test@";
        string password = "test";
        string fullname = "test test";
        accounts.NewAcc(email, password, fullname);
        AccountModel account = accounts.CheckLogin(email, password);
        Assert.AreEqual("test test", account.FullName);
        accounts.RemoveAcc(email);
    }

}