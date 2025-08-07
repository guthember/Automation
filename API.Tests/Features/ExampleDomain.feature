Feature: Example.com oldalon a H1 ellenőrzése

    Scenario: A főoldalon van <h1>Example Domain</h1>
        Given I have an HTTP client configured to "http://example.com"
        When I request the path "/"
        Then the HTTP status code should be 200
        And the response should contain "<h1>Example Domain</h1>"