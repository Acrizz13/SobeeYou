-------------------------------------------------
-- Names : Chase, Million, Alek, Josh
-- Team B
-- Capstone 
-- --------------------------------------------------------------------------------
USE SobeeYou;     -- Get out of the master database
SET NOCOUNT ON;
-- --------------------------------------------------------------------------------
--						Sobee You Tables
-- --------------------------------------------------------------------------------
IF OBJECT_ID ('TFlavors')					IS NOT NULL DROP TABLE TFlavors
IF OBJECT_ID ('TUserRoles')					IS NOT NULL DROP TABLE TUserRoles
IF OBJECT_ID ('TAdmins')					IS NOT NULL DROP TABLE TAdmins
IF OBJECT_ID ('TOrders')					IS NOT NULL DROP TABLE TOrders
IF OBJECT_ID ('TProductRecommendations')	IS NOT NULL DROP TABLE TProductRecommendations
IF OBJECT_ID ('TCustomerServiceTickets')	IS NOT NULL DROP TABLE TCustomerServiceTickets
IF OBJECT_ID ('TTicketStatus')				IS NOT NULL DROP TABLE TTicketStatus
IF OBJECT_ID ('TTicketCategories')			IS NOT NULL DROP TABLE TTicketCategories
IF OBJECT_ID ('TPermissions')				IS NOT NULL DROP TABLE TPermissions
IF OBJECT_ID ('TFavorites')					IS NOT NULL DROP TABLE TFavorites
IF OBJECT_ID ('TShoppingCarts')				IS NOT NULL DROP TABLE TShoppingCarts
IF OBJECT_ID ('TCoupons')					IS NOT NULL DROP TABLE TCoupons
IF OBJECT_ID ('TPromotions')				IS NOT NULL DROP TABLE TPromotions
IF OBJECT_ID ('TShippingMethods')			IS NOT NULL DROP TABLE TShippingMethods
IF OBJECT_ID ('TPayments')					IS NOT NULL DROP TABLE TPayments
IF OBJECT_ID ('TOrdersProducts')			IS NOT NULL DROP TABLE TOrdersProducts
IF OBJECT_ID ('TIngredients')				IS NOT NULL DROP TABLE TIngredients
IF OBJECT_ID ('TProductImages')				IS NOT NULL DROP TABLE TProductImages
IF OBJECT_ID ('TReviews')					IS NOT NULL DROP TABLE TReviews
IF OBJECT_ID ('TDrinkCategories')			IS NOT NULL DROP TABLE TDrinkCategories
IF OBJECT_ID ('TShippingStatus')			IS NOT NULL DROP TABLE TShippingStatus
IF OBJECT_ID ('TGenders')					IS NOT NULL DROP TABLE TGenders
IF OBJECT_ID ('TRaces')						IS NOT NULL DROP TABLE TRaces
IF OBJECT_ID ('TStates')					IS NOT NULL DROP TABLE TStates
IF OBJECT_ID ('TCities')					IS NOT NULL DROP TABLE TCities
IF OBJECT_ID ('TProducts')					IS NOT NULL DROP TABLE TProducts
IF OBJECT_ID ('TUsers')						IS NOT NULL DROP TABLE TUsers

-- --------------------------------------------------------------------------------
--						Create Tables
-- --------------------------------------------------------------------------------
CREATE TABLE TFlavors
(
	 intFlavorID			INTEGER			NOT NULL
	,strFlavor				VARCHAR(255)	NOT NULL
	,CONSTRAINT TFlavors_PK PRIMARY KEY ( intFlavorID )
)

CREATE TABLE TCities
(
	 intCityID			INTEGER			NOT NULL
	,strCity			VARCHAR(255)	NOT NULL
	,CONSTRAINT TCities_PK PRIMARY KEY ( intCityID )
)

CREATE TABLE TStates
(
	 intStateID			INTEGER			NOT NULL
	,strState			VARCHAR(255)	NOT NULL
	,CONSTRAINT TStates_PK PRIMARY KEY ( intStateID )
)

CREATE TABLE TRaces
(
	 intRaceID			INTEGER			NOT NULL
	,strRace			VARCHAR(255)	NOT NULL
	,CONSTRAINT TRaces_PK PRIMARY KEY ( intRaceID )
)

CREATE TABLE TGenders
(
	 intGenderID		INTEGER			NOT NULL
	,strGender			VARCHAR(255)	NOT NULL
	,CONSTRAINT TGenders_PK PRIMARY KEY ( intGenderID )
)


CREATE TABLE TShippingStatus
(	
	 intShippingStatusID			INTEGER			NOT NULL
	,strShippingStatus				VARCHAR(255)	NOT NULL
	,CONSTRAINT TShippingStatus_PK PRIMARY KEY ( intShippingStatusID )
)

CREATE TABLE TDrinkCategories
(	
	 intDrinkCategoryID				INTEGER			NOT NULL
	,strDrinkCategory				VARCHAR(255)	NOT NULL
	,CONSTRAINT TDrinkCategories_PK PRIMARY KEY ( intDrinkCategoryID )
)

CREATE TABLE TReviews
(	
	 intReviewID				INTEGER			NOT NULL
	,intUserID					INTEGER			NOT NULL
	,intProductID				INTEGER			NOT NULL
	,strReviewText				VARCHAR(1000)	NOT NULL
	,strRating					VARCHAR(255)	NOT NULL
	,CONSTRAINT TReviews_PK PRIMARY KEY ( intReviewID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TProductImages
(	
	 intProductImageID				INTEGER			NOT NULL
	,strProductImageURL				VARCHAR(1000)	NOT NULL
	,CONSTRAINT TProductImages_PK PRIMARY KEY ( intProductImageID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TIngredients
(	
	 intIngredientID			INTEGER			NOT NULL
	,strIngredient				VARCHAR(255)	NOT NULL
	,CONSTRAINT TIngredients_PK PRIMARY KEY ( intIngredientID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TOrdersProducts
(	
	 intOrdersProductID			INTEGER			NOT NULL
	 ,intProductID				INTEGER			NOT NULL
	,strOrdersProduct			VARCHAR(255)	NOT NULL
	,CONSTRAINT TOrdersProducts_PK PRIMARY KEY ( intOrdersProductID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TPayments
(	
	 intPaymentID					INTEGER			NOT NULL
	,strCreditCardDetails			VARCHAR(255)	NOT NULL
	,strBillingAddress				VARCHAR(255)	NOT NULL
	,CONSTRAINT TPayments_PK PRIMARY KEY ( intPaymentID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TShippingMethods
(	
	 intShippingMethodID			INTEGER			NOT NULL
	,strShippingName				VARCHAR(255)	NOT NULL
	,strBillingAddress				VARCHAR(255)	NOT NULL
	,dtmEstimatedDelivery			DATETIME		NOT NULL
	,strCost						VARCHAR(255)	NOT NULL
	,CONSTRAINT TShippingMethods_PK PRIMARY KEY ( intShippingMethodID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TPromotions
(	
	 intPromotionID					INTEGER			NOT NULL
	,strPromoCode					VARCHAR(255)	NOT NULL
	,strDiscountPercentage			VARCHAR(255)	NOT NULL
	,dtmExpirationDate				DATETIME		NOT NULL
	,CONSTRAINT TPromotions_PK PRIMARY KEY ( intPromotionID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TCoupons 
(	
	 intCouponID					INTEGER			NOT NULL
	,strCouponCode					VARCHAR(255)	NOT NULL
	,strDiscountAmount				VARCHAR(255)	NOT NULL
	,dtmExpirationDate				DATETIME		NOT NULL
	,CONSTRAINT TCoupons_PK PRIMARY KEY ( intCouponID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TShoppingCarts
(	
	 intShoppingCartID				INTEGER			NOT NULL
	,strCouponCode					VARCHAR(255)	NOT NULL
	,strDiscountAmount				VARCHAR(255)	NOT NULL
	,dtmExpirationDate				DATETIME		NOT NULL
	,CONSTRAINT TShoppingCarts_PK PRIMARY KEY ( intShoppingCartID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TFavorites
(	
	 intFavoriteID					INTEGER			NOT NULL
	,strFavorite					VARCHAR(255)	NOT NULL
	,CONSTRAINT TFavorites_PK PRIMARY KEY ( intFavoriteID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TPermissions 
(	
	 intPermissionID					INTEGER			NOT NULL
	,strPermissionName					VARCHAR(255)	NOT NULL
	,strDescription						VARCHAR(255)	NOT NULL
	,CONSTRAINT TPermissions_PK PRIMARY KEY ( intPermissionID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TTicketCategories 
(	
	 intTicketCategoryID			INTEGER			NOT NULL
	,strTicketCategory				VARCHAR(255)	NOT NULL
	,CONSTRAINT TTicketCategories_PK PRIMARY KEY ( intTicketCategoryID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TTicketStatus
(	
	 intTicketStatusID			INTEGER			NOT NULL
	,strTicketStatus			VARCHAR(255)	NOT NULL
	,CONSTRAINT TTicketStatus_PK PRIMARY KEY ( intTicketStatusID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TCustomerServiceTickets 
(	
	 intCustomerServiceTicketID			INTEGER			NOT NULL
	,intUserID							INTEGER			NOT NULL
	,intTicketCategoryID				INTEGER			NOT NULL
	,intTicketStatusID					INTEGER			NOT NULL
	,dtmTimeOfSubmission				DATETIME		NOT NULL
	,strDescription						VARCHAR(255)	NOT NULL
	,CONSTRAINT TCustomerServiceTickets_PK PRIMARY KEY ( intCustomerServiceTicketID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TProductRecommendations 
(	
	 intProductRecommendationID			INTEGER			NOT NULL
	,intUserID							INTEGER			NOT NULL
	,intProductID							INTEGER			NOT NULL
	,dtmTimeOfRecommendation			DATETIME		NOT NULL
	,strRelevantScore					VARCHAR(255)	NOT NULL
	,CONSTRAINT TProductRecommendations_PK PRIMARY KEY ( intProductRecommendationID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TProducts
(	
	 intProductID			INTEGER			NOT NULL
	,strName				VARCHAR(255)	NOT NULL
	,strPrice				VARCHAR(255)	NOT NULL
	,strStockAmount			VARCHAR(255)	NOT NULL
	,CONSTRAINT TProducts_PK PRIMARY KEY ( intProductID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TOrders
(	
	 intOrderID				INTEGER			NOT NULL
	,intUserID				INTEGER			NOT NULL
	,dtmOrdeDate			DATETIME		NOT NULL
	,strTotalPrice			VARCHAR(255)	NOT NULL
	,intShippingStatusID	INTEGER			NOT NULL
	,CONSTRAINT TOrders_PK PRIMARY KEY ( intOrderID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TAdmins
(	
	 intAdminID					INTEGER			NOT NULL
	,strAdminName				VARCHAR(255)	NOT NULL
	,CONSTRAINT TAdmins_PK PRIMARY KEY ( intAdminID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TUserRoles
(	
	 intUserRoleID					INTEGER			NOT NULL
	,strRole						VARCHAR(255)	NOT NULL
	,CONSTRAINT TUserRoles_PK PRIMARY KEY ( intUserRoleID )
)
-- --------------------------------------------------------------------------------

CREATE TABLE TUsers
(	
	 intUserID				INTEGER			NOT NULL
	,strUserName			VARCHAR(255)	NOT NULL
	,strShippingAddress		VARCHAR(255)	NOT NULL
	,strEmail				VARCHAR(255)	NOT NULL
	,strPassword			VARCHAR(255)	NOT NULL
	,CONSTRAINT TUsers_PK PRIMARY KEY ( intUserID )
)


-- --------------------------------------------------------------------------------
--						Referential Integrity 
-- --------------------------------------------------------------------------------
-- -	-----							------						---------
-- 1	TOrders							TUsers						intUserID
-- 2	TProductRecommendations			TUsers						intUserID
-- 3	TProductRecommendations			TProducts					intProductID
-- 4	TCustomerServiceTickets			TUsers						intUserID
-- 5	TCustomerServiceTickets			TTicketCategories			intTicketCategoryID
-- 6	TCustomerServiceTickets			TTicketStatus				intTicketStatusID
-- 7	TReviews						TUsers						intUserID
-- 8	TReviews						TProducts					intProductID
-- 8	TOrderProducts					TProducts					intProductID

-- -------------------------------------------------------------------------------
----1
--ALTER TABLE TCustomers	 ADD CONSTRAINT TCustomers_TStates_FK 
--FOREIGN KEY ( intStateID ) REFERENCES TStates (intStateID ) ON DELETE CASCADE
----1
ALTER TABLE TOrders	 ADD CONSTRAINT TOrders_TUsers_FK 
FOREIGN KEY ( intUserID ) REFERENCES TUsers (intUserID) ON DELETE CASCADE

----2
ALTER TABLE TProductRecommendations	 ADD CONSTRAINT TProductRecommendations_TUsers_FK 
FOREIGN KEY ( intUserID ) REFERENCES TUsers (intUserID) ON DELETE CASCADE

----3
ALTER TABLE TProductRecommendations	 ADD CONSTRAINT TProductRecommendations_TProducts_FK 
FOREIGN KEY ( intProductID ) REFERENCES TProducts (intProductID) ON DELETE CASCADE

----4
ALTER TABLE TCustomerServiceTickets	 ADD CONSTRAINT TCustomerServiceTickets_TUsers_FK 
FOREIGN KEY ( intUserID ) REFERENCES TUsers (intUserID) ON DELETE CASCADE

----5
ALTER TABLE TCustomerServiceTickets	 ADD CONSTRAINT TCustomerServiceTickets_TTicketCategories_FK 
FOREIGN KEY ( intTicketCategoryID ) REFERENCES TTicketCategories (intTicketCategoryID) ON DELETE CASCADE

----6
ALTER TABLE TCustomerServiceTickets	 ADD CONSTRAINT TCustomerServiceTickets_TTicketStatus_FK 
FOREIGN KEY ( intTicketStatusID ) REFERENCES TTicketStatus (intTicketStatusID) ON DELETE CASCADE

----7
ALTER TABLE TReviews  ADD CONSTRAINT TReviews_TUsers_FK 
FOREIGN KEY ( intUserID ) REFERENCES TUsers (intUserID) ON DELETE CASCADE

----8
ALTER TABLE TReviews  ADD CONSTRAINT TReviews_TProducts_FK 
FOREIGN KEY ( intProductID ) REFERENCES TProducts (intProductID) ON DELETE CASCADE

----9
ALTER TABLE TOrdersProducts  ADD CONSTRAINT TOrdersProducts_TProducts_FK 
FOREIGN KEY ( intProductID ) REFERENCES TProducts (intProductID) ON DELETE CASCADE
-- --------------------------------------------------------------------------------
--						INSERTS
-- --------------------------------------------------------------------------------
INSERT INTO TUsers( intUserID, strUserName, strShippingAddress, strEmail, strPassword)
VALUES				(1, 'CPSMALLS','325 Pictoria Dr', 'clpartin@cincinnatistate.edu', 'dog123')

INSERT INTO TFlavors( intFlavorID, strFlavor)
VALUES				(1, 'Berry Blast')
				   ,(2, 'Banana Bomb')
				   ,(3, 'Cherry Cocktail')

INSERT INTO TStates( intStateID, strState)
VALUES				(1, 'Ohio')
				   ,(2, 'Kentucky')
				   ,(3, 'Indiana')
				   ,(4, 'New York')
				   ,(5, 'Texas')
				   ,(6, 'Kansas')

INSERT INTO TCities( intCityID, strCity)
VALUES				(1, 'Cincinnati')
				   ,(2, 'Florence')
				   ,(3, 'Norwood')
				   ,(4, 'Milford')
				   ,(5, 'West Chester')
				   ,(6, 'Rome')

INSERT INTO TRaces( intRaceID, strRace)
VALUES				(1, 'Hispanic')
				   ,(2, 'African American')
				   ,(3, 'Cuacasion')
				   ,(4, 'Asian')
				   ,(5, 'Native')
				   ,(6, 'Euro')

INSERT INTO TGenders( intGenderID, strGender)
VALUES				(1, 'Male')
				   ,(2, 'Female')
				   ,(3, 'Other')

INSERT INTO TShippingStatus( intShippingStatusID, strShippingStatus)
VALUES				(1, 'Not-Shipped')
				   ,(2, 'Shipped')

INSERT INTO TTicketCategories( intTicketCategoryID, strTicketCategory)
VALUES				(1, 'front end')
				   ,(2, 'back end')

INSERT INTO TTicketStatus( intTicketStatusID, strTicketStatus)
VALUES				(1, 'Open')
				   ,(2, 'In-Progress')
				   ,(3, 'Closed')

INSERT INTO TPermissions( intPermissionID, strPermissionName, strDescription)
VALUES				(1, ' tba ', ' tba')

INSERT INTO TFavorites( intFavoriteID, strFavorite)
VALUES				(1, 'Banana Blitz')

INSERT INTO TShoppingCarts( intShoppingCartID, strCouponCode, strDiscountAmount, dtmExpirationDate)
VALUES				(1, '276-C1F', '5.00', '02/14/2024')

INSERT INTO TCoupons( intCouponID, strCouponCode, strDiscountAmount, dtmExpirationDate)
VALUES				(1, '276-C1F', '5.00', '02/14/2024')

INSERT INTO TPromotions( intPromotionID, strPromoCode, strDiscountPercentage, dtmExpirationDate)
VALUES				(1, '4E5-JGT', '.10', '02/14/2024')

INSERT INTO TShippingMethods( intShippingMethodID, strShippingName, strBillingAddress, dtmEstimatedDelivery, strCost)
VALUES				(1, 'Fed-Ex', '325 Pictoria Dr', '02/14/2024', '3.99')

INSERT INTO TPayments( intPaymentID, strCreditCardDetails, strBillingAddress)
VALUES				(1, '4045', '325 Pictoria Dr')

INSERT INTO TIngredients( intIngredientID, strIngredient)
VALUES				(1, 'h20')

INSERT INTO TDrinkCategories( intDrinkCategoryID, strDrinkCategory)
VALUES				(1, 'Soft Drinks')
				   ,(2, 'Juices')
				   ,(3, 'Tea')

INSERT INTO TProductImages( intProductImageID, strProductImageURL)
VALUES				(1, 'URL LINK')

INSERT INTO TUserRoles( intUserRoleID, strRole)
VALUES				(1, 'Reg. User')
				   ,(2, 'Administrator')
				   ,(3, 'Moderator')

INSERT INTO TAdmins( intAdminID, strAdminName)
VALUES				(1, 'Chase')
				   ,(2, 'Alek')
				   ,(3, 'Million')
				   ,(4, 'Josh')

INSERT INTO TProducts( intProductID, strName, strPrice, strStockAmount)
VALUES				(1, 'Banana Blitz (NA)', '13.69', '13')

INSERT INTO TCustomerServiceTickets( intCustomerServiceTicketID, intUserID, intTicketCategoryID, intTicketStatusID, dtmTimeOfSubmission, strDescription)
VALUES				(1, 1, 1, 1, '02/14/2024', 'site is down')

INSERT INTO TOrdersProducts( intOrdersProductID, intProductID, strOrdersProduct)
VALUES				(1, 1, 'Banana Blitz')

INSERT INTO TReviews( intReviewID, intUserID, intProductID, strReviewText, strRating)
VALUES				(1, 1, 1, 'The best drink.', '5/5')

INSERT INTO TOrders( intOrderID, intUserID, dtmOrdeDate, strTotalPrice, intShippingStatusID)
VALUES				(1, 1, '02/14/2024', '13.69', 1)

INSERT INTO TProductRecommendations( intProductRecommendationID, intUserID, intProductID, dtmTimeOfRecommendation,strRelevantScore)
VALUES				(1, 1, 1, '02/14/2024', '5/5')
-- --------------------------------------------------------------------------------
--						Joins
-- --------------------------------------------------------------------------------

