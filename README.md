# Payment Gateway Project

## For testing purposes, some valid and invalid values have been designated
Valid API Key: `validkey`

Valid card number: `1111222233334444`

Invalid API key: `invalidkey`

Invalid card number: `0000000000000000`

## Process
### Create Payment
1. Request is sent to the gateway
2. API key is checked for validity
3. Card number is validated against internal rules (currently just length and that it contains only numbers)
4. Payment details are stored with a `PENDING` status
5. Request is sent to the bank
6. The response from the bank is used to update the payment status
7. The ID of the new payment is returned

### Get Payment
1. Request is sent to the gateway
2. API key is checked for validity
3. Payment ID is passed to the payment microservice
4. Payment details are returned

## Premade valid api requests
``

## Improvements