using InveonBootcamp.Homework;

public interface IFakeAdminSmsEmailRepository
{
	void AddAdminEmail(AdminEmail email);
	IEnumerable<AdminEmail> GetAllAdminEmails();

	void NotifyAdminNewProductAdded(Product product);
}

public class FakeAdminSmsEmailRepository : IFakeAdminSmsEmailRepository
{
	private static List<AdminEmail> _emailMessages;

	public FakeAdminSmsEmailRepository()
	{

		_emailMessages = new List<AdminEmail>
		{
			new AdminEmail { Subject = "Test Email 1", Body = "This is a test email body."},
			new AdminEmail { Subject = "Test Email 2", Body = "This is another test email body."}
		};
	}

	public void AddAdminEmail(AdminEmail email)
	{
		_emailMessages.Add(email);
	}

	public void NotifyAdminNewProductAdded(Product product)
	{
		_emailMessages.Add(new AdminEmail { Subject = "New Product Added", Body = $"New product named {product.Name} added" });
	}

	public IEnumerable<AdminEmail> GetAllAdminEmails()
	{
		return _emailMessages;
	}
}

public class AdminEmail
{
	public string Subject { get; set; }
	public string Body { get; set; }
}
