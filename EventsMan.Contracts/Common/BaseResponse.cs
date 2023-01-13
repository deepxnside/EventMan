namespace EventsMan.Contracts.Common;

public class BaseResponse
{
   public BaseResponse()
   {
      Success = true;
   }

   public BaseResponse(string message)
   {
      Success = true;
      Message = message;
   }

   public BaseResponse(string message, bool success)
   {
      Message = message;
      Success = success;
   }

   public string Message { get; set; }
   public bool Success { get; set; }
   public List<string>? ValidationErrors { get; set; }
}