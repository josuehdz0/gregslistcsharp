CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS houses(
  id INT AUTO_INCREMENT  PRIMARY KEY,
  rooms INT NOT NULL DEFAULT 1,
  bathrooms INT NOT NULL DEFAULT 1,
  year INT NOT NULL DEFAULT 2025,
  price INT NOT NULL DEFAULT 100000,
  description TEXT,
  imgUrl VARCHAR(255) NOT NULL
) default charset utf8 COMMENT '';
DROP table IF EXISTS houses;


INSERT INTO houses
(rooms, bathrooms, year, price, description, imgUrl)
VALUES
(3,2,1984,380000,"Cute little house", "https://cdn.vox-cdn.com/thumbor/WYOw6PDxFufn9nIGpinFy0SVRro=/1400x1050/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/20026609/001_344965_Edits_001_8812424.jpg")
