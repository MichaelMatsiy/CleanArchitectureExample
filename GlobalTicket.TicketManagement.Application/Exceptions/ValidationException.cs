using FluentValidation.Results;

namespace GlobalTicket.TicketManagement.Application.Exceptions
{
	public class ValidationException : Exception
	{
		public List<string> ValidationErrors { get; set; }

		public ValidationException(ValidationResult validationResult) 
		{
			ValidationErrors = new List<string>(validationResult.Errors.Count);

			foreach (var error in validationResult.Errors) 
			{
				ValidationErrors.Add(error.ErrorMessage);
			}
		}
	}
}
