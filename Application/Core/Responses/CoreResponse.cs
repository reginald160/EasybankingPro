using Application.Common;
using Application.Core.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Responses
{
	public static class CoreResponse
	{
		public static Response OnSaveResponse (object responseData)
		{

			Response response = new Response
			{
				ResponseCode = ResponseCode.SuccesFullOperation,
				ResponseMessage = ResponseMessage.RecordOnCreationMessage,
				Status = ResponseStatus.Success,
				Data = responseData

			};

			return response;
		}
		public static Response OnSuccess(object responseData)
		{

			Response response = new Response
			{
				ResponseCode = ResponseCode.SuccesFullOperation,
				ResponseMessage = ResponseMessage.SuccesFullOperationMessage,
				Status = ResponseStatus.Success,
				Data = responseData

			};

			return response;
		}
		public static Response OnUpdateResponse(object responseData)
		{

			Response response = new Response
			{
				ResponseCode = ResponseCode.SuccesFullOperation,
				ResponseMessage = ResponseMessage.RecordOnUpdateMessage,
				Status = ResponseStatus.Success,
				Data = responseData

			};

			return response;
		}

		public static Response NotFoundResponse(object responseData, string responseMessage)
		{

			Response response = new Response
			{
				ResponseCode = ResponseCode.NotFound,
				ResponseMessage = responseMessage,
				Status = ResponseStatus.Failed,
				Data = responseData

			};

			return response;
		}

		public static Response GlobalResponse(object responseData, string responseMessage, string status, int responseCode)
		{

			Response response = new Response
			{
				ResponseCode = responseCode,
				ResponseMessage = responseMessage,
				Status = status,
				Data = responseData

			};

			return response;
		}

		public static Response OnFailureResponse(object responseData, string? responseMessage)
		{
			var message = String.Empty;
			if (String.IsNullOrWhiteSpace(responseMessage))
				message = ResponseMessage.FailedOperationMessage;

			Response response = new Response
			{
				ResponseCode = ResponseCode.FailedOperation,
				ResponseMessage = responseMessage,
				Status = ResponseStatus.Failed,
				Data = responseData

			};

			return response;
		}
	}
}
