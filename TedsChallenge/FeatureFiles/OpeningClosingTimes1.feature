Feature: OpeningClosingTimes1
	

@mytag
Scenario: VerifyOpeningClosingTimes
		Given Landed on Yelp site
		When Search for an restaurant
		Then Verify Opening and Closing time displayed
