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
    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow("user@", null)]
    [DataRow(null, "password")]
    [DataRow("di@g.com", "password")]
    [DataRow("email@", "123")]
    [DataRow("di@g.com", "123")]
    public void CheckLoginTest(string email, string password)
    {
        AccountsLogic accounts = new AccountsLogic();
        AccountModel account = accounts.CheckLogin(email, password);
        bool accountornot = false;
        if (account == null)
        {
            accountornot = true;
            Assert.IsTrue(accountornot);
        }
        else
        {
            Assert.IsFalse(accountornot);
            Assert.AreEqual("Diana Faliuta", account.FullName);
        }
    }
}