# Day 2 - Bootcamp SQL & .Net OOP

# SQL
## Table Spesification
```sql
CREATE TABLE TableSpesification (
	TableId VARCHAR(36) NOT NULL PRIMARY KEY,
    TableNumber INT,
    ChairNumber INT,
    TablePic VARCHAR(75) NOT NULL,
    TableType VARCHAR(50)
);

INSERT INTO TableSpesification (TableId, TableNumber, ChairNumber, TablePic, TableType) VALUES
('1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6', 1, 4, 'table1.jpg', 'Round'),
('2b3c4d5e-6f7g8h9i-0j1k-l2m3n4o5p6q7', 2, 6, 'table2.jpg', 'Square'),
('3c4d5e6f-7g8h9i0j-1k2l-m3n4o5p6q7r8', 3, 2, 'table3.jpg', 'Rectangle'),
('4d5e6f7g-8h9i0j1k-2l3m-n4o5p6q7r8s9', 4, 4, 'table4.jpg', 'Oval'),
('5e6f7g8h-9i0j1k2l-3m4n-o5p6q7r8s9t0', 5, 8, 'table5.jpg', 'High-top'),
('6f7g8h9i-0j1k2l3m-4n5o-p6q7r8s9t0u1', 6, 2, 'table6.jpg', 'Low'),
('7g8h9i0j-1k2l3m4n-5o6p-q7r8s9t0u1v2', 7, 4, 'table7.jpg', 'Picnic'),
('8h9i0j1k-2l3m4n5o-6p7q-r8s9t0u1v2w3', 8, 6, 'table8.jpg', 'Café'),
('9i0j1k2l-3m4n5o6p-7q8r-s9t0u1v2w3x4', 9, 4, 'table9.jpg', 'Bar'),
('0j1k2l3m-4n5o6p7q-8r9s-t0u1v2w3x4y5', 10, 10, 'table10.jpg', 'Family');
```

## Table Order (1 to Many)
```sql
CREATE TABLE TableOrder (
	TableOrderId VARCHAR(36) NOT NULL PRIMARY KEY,
    TableId VARCHAR(36) NOT NULL,
    MenuName VARCHAR(75) NOT NULL,
    QuantityOrder INT,
    FOREIGN KEY(TableOrderId) REFERENCES TableSpesification(TableId)
);

INSERT INTO TableOrder (TableOrderId, TableId, MenuName, QuantityOrder) VALUES
('1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6', '1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6', 'Pizza', 2),
('2b3c4d5e-6f7g8h9i-0j1k-l2m3n4o5p6q7', '2b3c4d5e-6f7g8h9i-0j1k-l2m3n4o5p6q7', 'Pasta', 1),
('3c4d5e6f-7g8h9i0j-1k2l-m3n4o5p6q7r8', '3c4d5e6f-7g8h9i0j-1k2l-m3n4o5p6q7r8', 'Salad', 3),
('4d5e6f7g-8h9i0j1k-2l3m-n4o5p6q7r8s9', '4d5e6f7g-8h9i0j1k-2l3m-n4o5p6q7r8s9', 'Burger', 4),
('5e6f7g8h-9i0j1k2l-3m4n-o5p6q7r8s9t0', '5e6f7g8h-9i0j1k2l-3m4n-o5p6q7r8s9t0', 'Soda', 5),
('6f7g8h9i-0j1k2l3m-4n5o-p6q7r8s9t0u1', '6f7g8h9i-0j1k2l3m-4n5o-p6q7r8s9t0u1', 'Coffee', 2),
('7g8h9i0j-1k2l3m4n-5o6p-q7r8s9t0u1v2', '7g8h9i0j-1k2l3m4n-5o6p-q7r8s9t0u1v2', 'Tea', 1),
('8h9i0j1k-2l3m4n5o-6p7q-r8s9t0u1v2w3', '8h9i0j1k-2l3m4n5o-6p7q-r8s9t0u1v2w3', 'Dessert', 6),
('9i0j1k2l-3m4n5o6p-7q8r-s9t0u1v2w3x4', '9i0j1k2l-3m4n5o6p-7q8r-s9t0u1v2w3x4', 'Fries', 3),
('0j1k2l3m-4n5o6p7q-8r9s-t0u1v2w3x4y5', '0j1k2l3m-4n5o6p7q-8r9s-t0u1v2w3x4y5', 'Ice Cream', 2);

```

## Table Order Details (1 to 1)
```sql
CREATE TABLE TableOrderDetails (
    OrderDetailsId VARCHAR(36) NOT NULL PRIMARY KEY,
    TableId VARCHAR(36) NOT NULL UNIQUE,
    TableOrderId VARCHAR(36) NOT NULL UNIQUE,
    OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (TableId) REFERENCES TableSpesification(TableId),
    FOREIGN KEY (TableOrderId) REFERENCES TableOrder(TableOrderId)
);

INSERT INTO TableOrderDetails (OrderDetailsId, TableId, TableOrderId, OrderDate, TotalAmount) VALUES
('1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6', '1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6', '1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6', '2024-08-21 12:30:00', 25.50),
('2b3c4d5e-6f7g8h9i-0j1k-l2m3n4o5p6q7', '2b3c4d5e-6f7g8h9i-0j1k-l2m3n4o5p6q7', '2b3c4d5e-6f7g8h9i-0j1k-l2m3n4o5p6q7', '2024-08-21 13:00:00', 15.00),
('3c4d5e6f-7g8h9i0j-1k2l-m3n4o5p6q7r8', '3c4d5e6f-7g8h9i0j-1k2l-m3n4o5p6q7r8', '3c4d5e6f-7g8h9i0j-1k2l-m3n4o5p6q7r8', '2024-08-21 13:15:00', 30.75),
('4d5e6f7g-8h9i0j1k-2l3m-n4o5p6q7r8s9', '4d5e6f7g-8h9i0j1k-2l3m-n4o5p6q7r8s9', '4d5e6f7g-8h9i0j1k-2l3m-n4o5p6q7r8s9', '2024-08-21 14:00:00', 45.00),
('5e6f7g8h-9i0j1k2l-3m4n-o5p6q7r8s9t0', '5e6f7g8h-9i0j1k2l-3m4n-o5p6q7r8s9t0', '5e6f7g8h-9i0j1k2l-3m4n-o5p6q7r8s9t0', '2024-08-21 14:30:00', 22.50),
('6f7g8h9i-0j1k2l3m-4n5o-p6q7r8s9t0u1', '6f7g8h9i-0j1k2l3m-4n5o-p6q7r8s9t0u1', '6f7g8h9i-0j1k2l3m-4n5o-p6q7r8s9t0u1', '2024-08-21 15:00:00', 18.00),
('7g8h9i0j-1k2l3m4n-5o6p-q7r8s9t0u1v2', '7g8h9i0j-1k2l3m4n-5o6p-q7r8s9t0u1v2', '7g8h9i0j-1k2l3m4n-5o6p-q7r8s9t0u1v2', '2024-08-21 15:30:00', 12.00),
('8h9i0j1k-2l3m4n5o-6p7q-r8s9t0u1v2w3', '8h9i0j1k-2l3m4n5o-6p7q-r8s9t0u1v2w3', '8h9i0j1k-2l3m4n5o-6p7q-r8s9t0u1v2w3', '2024-08-21 16:00:00', 50.00),
('9i0j1k2l-3m4n5o6p-7q8r-s9t0u1v2w3x4', '9i0j1k2l-3m4n5o6p-7q8r-s9t0u1v2w3x4', '9i0j1k2l-3m4n5o6p-7q8r-s9t0u1v2w3x4', '2024-08-21 16:30:00', 27.25),
('0j1k2l3m-4n5o6p7q-8r9s-t0u1v2w3x4y5', '0j1k2l3m-4n5o6p7q-8r9s-t0u1v2w3x4y5', '0j1k2l3m-4n5o6p7q-8r9s-t0u1v2w3x4y5', '2024-08-21 17:00:00', 33.60);
```

## Table Order History (Many to Many)
```sql
CREATE TABLE TableOrderHistory (
    HistoryId VARCHAR(36) NOT NULL PRIMARY KEY,
    TableId VARCHAR(36) NOT NULL,
    TableOrderId VARCHAR(36) NOT NULL,
    OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (TableId) REFERENCES TableSpesification(TableId),
    FOREIGN KEY (TableOrderId) REFERENCES TableOrder(TableOrderId)
);

INSERT INTO TableOrderHistory (HistoryId, TableId, TableOrderId, OrderDate, TotalAmount) VALUES
('1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6', '1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6', '1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6', '2024-08-21 12:30:00', 25.50),
('2b3c4d5e-6f7g8h9i-0j1k-l2m3n4o5p6q7', '1a2b3c4d-5e6f-7g8h-9i0j-k1l2m3n4o5p6', '2b3c4d5e-6f7g8h9i-0j1k-l2m3n4o5p6q7', '2024-08-21 13:00:00', 15.00),
('3c4d5e6f-7g8h9i0j-1k2l-m3n4o5p6q7r8', '2b3c4d5e-6f7g8h9i-0j1k-l2m3n4o5p6q7', '3c4d5e6f-7g8h9i0j-1k2l-m3n4o5p6q7r8', '2024-08-21 13:15:00', 30.75),
('4d5e6f7g-8h9i0j1k-2l3m-n4o5p6q7r8s9', '3c4d5e6f-7g8h9i0j-1k2l-m3n4o5p6q7r8', '4d5e6f7g-8h9i0j1k-2l3m-n4o5p6q7r8s9', '2024-08-21 14:00:00', 45.00),
('5e6f7g8h-9i0j1k2l-3m4n-o5p6q7r8s9t0', '4d5e6f7g-8h9i0j1k-2l3m-n4o5p6q7r8s9', '5e6f7g8h-9i0j1k2l-3m4n-o5p6q7r8s9t0', '2024-08-21 14:30:00', 22.50),
('6f7g8h9i-0j1k2l3m-4n5o-p6q7r8s9t0u1', '5e6f7g8h-9i0j1k2l-3m4n-o5p6q7r8s9t0', '6f7g8h9i-0j1k2l3m-4n5o-p6q7r8s9t0u1', '2024-08-21 15:00:00', 18.00),
('7g8h9i0j-1k2l3m4n-5o6p-q7r8s9t0u1v2', '6f7g8h9i-0j1k2l3m-4n5o-p6q7r8s9t0u1', '7g8h9i0j-1k2l3m4n-5o6p-q7r8s9t0u1v2', '2024-08-21 15:30:00', 12.00),
('8h9i0j1k-2l3m4n5o-6p7q-r8s9t0u1v2w3', '7g8h9i0j-1k2l3m4n-5o6p-q7r8s9t0u1v2', '8h9i0j1k-2l3m4n5o-6p7q-r8s9t0u1v2w3', '2024-08-21 16:00:00', 50.00),
('9i0j1k2l-3m4n5o6p-7q8r-s9t0u1v2w3x4', '8h9i0j1k-2l3m4n5o-6p7q-r8s9t0u1v2w3', '9i0j1k2l-3m4n5o6p-7q8r-s9t0u1v2w3x4', '2024-08-21 16:30:00', 27.25),
('0j1k2l3m-4n5o6p7q-8r9s-t0u1v2w3x4y5', '9i0j1k2l-3m4n5o6p-7q8r-s9t0u1v2w3x4', '0j1k2l3m-4n5o6p7q-8r9s-t0u1v2w3x4y5', '2024-08-21 17:00:00', 33.60);
```

## Table Join TableSpesification with TableOrder
```sql
SELECT 
    ts.*,
    tor.TableOrderId,
    tor.MenuName,
    tor.QuantityOrder
FROM 
    TableSpesification ts
LEFT JOIN 
    TableOrder tor ON ts.TableId = tor.TableId;
```

## Result Relation SQL
![alt text](https://github.com/havidalbar/day21-bootcamp/blob/main/relation.png)

## Result Result Join SQL
![alt text](https://github.com/havidalbar/day21-bootcamp/blob/main/result_join.png)
