USE [EntityFrameworkSample]
GO

-- =============================================
-- Author:		Nasser pourahmad
-- Create date: 2024/08/02
-- Description:	sample

-- EXECUTE SP_GetSumPriceAtEachCategoryWithPrice @Price = 1

-- =============================================
CREATE PROCEDURE [dbo].[SP_GetSumPriceAtEachCategory]
	@Price bigint =  1
AS
BEGIN
	SELECT ctg.Id, ctg.Name , CAST(SUM(prd.Price)AS decimal) AS Price FROM dbo.Categories AS ctg 
	LEFT JOIN dbo.Products AS prd 
		ON ctg.Id = prd.CategoryId
	WHERE prd.Price >= @Price
	GROUP BY ctg.Id, ctg.Name
END


-- =============================================
-- Author:		Nasser pourahmad
-- Create date: 2024/08/02
-- Description:	sample

-- EXECUTE SP_GetSumPriceAtEachCategoryWithPrice @Price = 1

-- =============================================
CREATE PROCEDURE SP_GetSumPriceAtEachCategoryWithPrice
	@Price bigint =  1
AS
BEGIN
	SELECT ctg.Id, ctg.Name , CAST(SUM(prd.Price)AS decimal) AS Price FROM dbo.Categories AS ctg 
	LEFT JOIN dbo.Products AS prd 
		ON ctg.Id = prd.CategoryId
	WHERE prd.Price >= @Price
	GROUP BY ctg.Id, ctg.Name
END
GO