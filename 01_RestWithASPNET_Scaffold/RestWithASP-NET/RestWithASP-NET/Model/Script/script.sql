CREATE TABLE person (
    Id BIGINT NOT NULL IDENTITY(1,1),
    address NVARCHAR(80) NOT NULL,
    first_name NVARCHAR(50) NOT NULL,
    gender NVARCHAR(6) NOT NULL,
    last_name NVARCHAR(80) NOT NULL,
    PRIMARY KEY (Id)
);
