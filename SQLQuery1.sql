Create Trigger SalesStockdecrease
on SalesActions 
after insert 
as
Declare @ProductID int
Declare @Piece int
Select @ProductID=Productiid ,@Piece=Piece from inserted
update Products Set Stock=Stock-@Piece where ProductID=@ProductID
 