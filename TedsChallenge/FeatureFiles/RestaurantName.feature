Feature: RestaurantName


@mytag
Scenario: Verify restaurant name
	Given Navigated to Yelp site
	When Search for a restaurant
	Then Display and verify the name

