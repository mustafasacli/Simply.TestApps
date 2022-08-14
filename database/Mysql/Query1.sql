-- SELECT * FROM orderdetails WHERE productCode='S18_2325';
-- SELECT * FROM (select * from `classicmodels`.`orderdetails` WHERE `productCode` = 'S18_2325') AS EXT1 LIMIT 0, 1
-- SELECT EXT3.* FROM (
SELECT EXT2.* FROM (SELECT EXT1.*, ROW_NUMBER() OVER() AS RN1 FROM (select * from `classicmodels`.`orderdetails` 
WHERE `productCode` = 'S18_2325') AS EXT1) AS EXT2 ORDER BY EXT2.RN1 DESC LIMIT 0, 1
-- ) AS EXT3 ORDER BY EXT3.RN1 LIMIT 0, 1


SELECT EXT2.* FROM (SELECT EXT1.*, ROW_NUMBER() OVER() AS RN1 FROM ( #SQL_SCRIPT# ) AS EXT1) AS EXT2 ORDER BY EXT2.RN1 DESC LIMIT 0, 1

SELECT EXT2.* FROM (SELECT EXT1.*, ROW_NUMBER() OVER() AS RN1 FROM ( #SQL_SCRIPT# ) AS EXT1) AS EXT2 ORDER BY EXT2.RN1 LIMIT 0, 1
select * from `classicmodels`.`orderdetails` WHERE `productCode` = 'S18_2325'

SELECT * FROM `classicmodels`.`customers` WHERE `customerNumber` = 103