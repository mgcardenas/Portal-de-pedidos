namespace PortalDePedidosServidor.Servicios
{
    using System;
    using Google.Api.Gax.ResourceNames;
    using Google.Cloud.RecaptchaEnterprise.V1;
    using PortalDePedidosShared;
    using PortalDePedidosShared.LoginVM;

    public class RecaptchaService
    {
        private LogService _logService;
        private IConfiguration _configuration;

        public RecaptchaService(LogService logService, IConfiguration configuration)
        {
            _logService = logService;
            _configuration = configuration;
            //seteo credenciales de goolge cloud
            try
            {
                System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", _configuration.GetConnectionString("GoogleApplicationCredentialsPath"));
            }catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
        }
        // Create an assessment to analyze the risk of a UI action.
        // projectID: Your Google Cloud Project ID.
        // recaptchaKey: The reCAPTCHA key associated with the site/app
        // token: The generated token obtained from the client.
        // recaptchaAction: Action name corresponding to the token.
        //public bool createAssessment(string token )
        public bool createAssessment(ReCaptchaVM reCaptcha)
        {
            string recaptchaAction = reCaptcha.Action;
            //string recaptchaAction = "LOGIN";
            //string recaptchaAction = "";
            //string projectID = "portaldeclientespcr"; 
            string projectID = "portaldeclientespcr"; 
            string recaptchaKey = "6LdXVmEqAAAAADuGZWx60PCX8INI6JC_rVT-n6pY";
            //string recaptchaKey = "6LdAj3UqAAAAAAp5d8JjPOuI6rVo1hUW0TYLZQ1J";
            // Create the reCAPTCHA client.
            // TODO: Cache the client generation code (recommended) or call client.close() before exiting the method.
            RecaptchaEnterpriseServiceClient client = RecaptchaEnterpriseServiceClient.Create();

            ProjectName projectName = new ProjectName(projectID);

            // Build the assessment request.
            CreateAssessmentRequest createAssessmentRequest = new CreateAssessmentRequest()
            {
                Assessment = new Assessment()
                {
                    // Set the properties of the event to be tracked.
                    Event = new Event()
                    {
                        SiteKey = recaptchaKey,
                        Token = reCaptcha.Token,
                        ExpectedAction = recaptchaAction
                    },
                },
                ParentAsProjectName = projectName
            };

            Assessment response = client.CreateAssessment(createAssessmentRequest);

            // Check if the token is valid.
            if (response.TokenProperties.Valid == false)
            {
                _logService.WriteLogRecaptcha("The CreateAssessment call failed because the token was: " +
                    response.TokenProperties.InvalidReason.ToString());
                return false;
            }

            // Check if the expected action was executed.
            if (response.TokenProperties.Action != recaptchaAction)
            {
                _logService.WriteLogRecaptcha("The action attribute in reCAPTCHA tag is: " +
                    response.TokenProperties.Action.ToString());
                _logService.WriteLogRecaptcha("The action attribute in the reCAPTCHA tag does not " +
                    "match the action you are expecting to score");
                return false;
            }

            // Get the risk score and the reason(s).
            // For more information on interpreting the assessment, see:
            // https://cloud.google.com/recaptcha-enterprise/docs/interpret-assessment
            _logService.WriteLogRecaptcha("The reCAPTCHA "+ response.TokenProperties.Action.ToString() + " score is: " + ((decimal)response.RiskAnalysis.Score));

            foreach (RiskAnalysis.Types.ClassificationReason reason in response.RiskAnalysis.Reasons)
            {
                _logService.WriteLogRecaptcha(reason.ToString());
            }
            return response.RiskAnalysis.Score > 0.6;
        }

    }
}
