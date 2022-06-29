Code Review:
Add appsettings for validation values. eg Max Credit Score, Higher and Lower Loan Values
Swap int's for Uint's as values always positive. n.b. Cast int.TryParse to unit. 
Move ClaimSuccessful() logic from model to service
Feedback less info as per specifications request.
Move CriteriaRepo instantiation from GetCritiera to constructor. 
