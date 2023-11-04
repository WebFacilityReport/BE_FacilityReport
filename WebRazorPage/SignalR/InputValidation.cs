using Infrastructure.Model.Request.RequestFeedBack;
using Infrastructure.Model.Request.RequestTask;

namespace WebRazorPage.SignalR
{
    public class InputValidation
    {
        public RequestFeedBackRZError ValidateCreateFeedback(RequestFeedBackRZ request)
        {
            var errors = new RequestFeedBackRZError();

            var comment = request.Comment;
            if (comment == "")
            {
                errors.CommentError = "Comment is required";
            }
            return errors;
        }

        public RequestUpdateStatusHistoryRZError ValidateUpdateStatusHistory(RequestUpdateStatusHistoryRZ request)
        {
            var errors = new RequestUpdateStatusHistoryRZError();

            var title = request.Title;
            if (title == "")
            {
                errors.TitleError = "Title is required";
            }

            var descriptionJob = request.DescriptionJob;
            if (descriptionJob == "")
            {
                errors.DescriptionJobError = "Description job is required";
            }
            return errors;
        }

        public RequestTaskEquipmentRZError ValidateTaskEquipment(RequestTaskEquipmentRZ request)
        {
            var errors = new RequestTaskEquipmentRZError();

            var title = request.Title;
            if (title == "")
            {
                errors.TitleError = "Title is required";
            }

            var descriptionJob = request.DescriptionJob;
            if (descriptionJob == "")
            {
                errors.DescriptionJobError = "Description job is required";
            }

            var location = request.Location;
            if (location == "")
            {
                errors.LocationError = "Location is required";
            }
            return errors;
        }

        public RequestTaskResourceRzError ValidateTaskResource(RequestTaskResourceRz request)
        {
            var errors = new RequestTaskResourceRzError();

            var title = request.Title;
            if (title == "")
            {
                errors.TitleError = "Title is required";
            }

            var descriptionJob = request.DescriptionJob;
            if (descriptionJob == "")
            {
                errors.DescriptionJobError = "Description job is required";
            }

            return errors;
        }
    }
}

public class RequestFeedBackRZError
{
    public string CommentError { get; set; }

    public RequestFeedBackRZError()
    {
        CommentError = string.Empty;
    }
    public bool HasError()
    {
        return !string.IsNullOrEmpty(CommentError);
    }

    public string CreateMessage()
    {
        if (HasError())
        {
            var errorMessage = "Validation Errors:";
            if (!string.IsNullOrEmpty(CommentError))
            {
                errorMessage += $"\n- Comment: {CommentError}";
            }
            return errorMessage;
        }

        return string.Empty;
    }

}

public class RequestUpdateStatusHistoryRZError
{
    public string TitleError { get; set; }
    public string DescriptionJobError { get; set; }

    public RequestUpdateStatusHistoryRZError()
    {
        TitleError = string.Empty;
        DescriptionJobError = string.Empty;
    }

    public bool HasError()
    {
        return 
           !string.IsNullOrEmpty(TitleError)
        || !string.IsNullOrEmpty(DescriptionJobError);
    }

    public string CreateMessage()
    {
        if (HasError())
        {
            var errorMessage = "Validation Errors:";
            if (!string.IsNullOrEmpty(TitleError))
            {
                errorMessage += $"\n- {TitleError}";
            }

            if (!string.IsNullOrEmpty(DescriptionJobError))
            {
                errorMessage += $"\n- {DescriptionJobError}";
            }

            return errorMessage;
        }
        return string.Empty;
    }
}

public class RequestTaskEquipmentRZError
{
    public string TitleError { get; set; }
    public string DescriptionJobError { get; set; }

    public string LocationError { get; set; }

    public RequestTaskEquipmentRZError()
    {
        TitleError = string.Empty;
        DescriptionJobError = string.Empty;
        LocationError = string.Empty;
    }

    public bool HasError()
    {
        return
           !string.IsNullOrEmpty(TitleError)
        || !string.IsNullOrEmpty(DescriptionJobError)
        || !string.IsNullOrEmpty(LocationError);
        ;
    }

    public string CreateMessage()
    {
        if (HasError())
        {
            var errorMessage = "Validation Errors:";
            if (!string.IsNullOrEmpty(TitleError))
            {
                errorMessage += $"\n- Title: {TitleError}";
            }

            if (!string.IsNullOrEmpty(DescriptionJobError))
            {
                errorMessage += $"\n- Description Job: {DescriptionJobError}";
            }

            if (!string.IsNullOrEmpty(LocationError))
            {
                errorMessage += $"\n- Location: {LocationError}";
            }

            return errorMessage;
        }

        return string.Empty;
    }
}

public class RequestTaskResourceRzError
{
    public string TitleError { get; set; }
    public string DescriptionJobError { get; set; }
    public RequestTaskResourceRzError()
    {
        TitleError = string.Empty;
        DescriptionJobError = string.Empty;
    }

    public bool HasError()
    {
        return
           !string.IsNullOrEmpty(TitleError)
        || !string.IsNullOrEmpty(DescriptionJobError)
       ;
    }

    public string CreateMessage()
    {
        if (HasError())
        {
            var errorMessage = "Validation Errors:";
            if (!string.IsNullOrEmpty(TitleError))
            {
                errorMessage += $"\n- Title: {TitleError}";
            }

            if (!string.IsNullOrEmpty(DescriptionJobError))
            {
                errorMessage += $"\n- Description Job: {DescriptionJobError}";
            }

            return errorMessage;
        }
        return string.Empty;
    }
}

