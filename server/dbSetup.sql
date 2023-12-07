CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS restaurants(
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name CHAR(100) NOT NULL,
    imgUrl VARCHAR(500) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    visits INT NOT NULL DEFAULT 0,
    isShutDown BOOL NOT NULL DEFAULT false,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

INSERT INTO 
restaurants (name, imgUrl, description, creatorId)
VALUES ("Arby's", 'https://images.unsplash.com/photo-1529692236671-f1f6cf9683ba?q=80&w=2340&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', "Best restaurant in the entire world.", '65677a22619a399a33aeef33');
INSERT INTO 
restaurants (name, imgUrl, description, creatorId)
VALUES ("MilesDonalds", 'https://images.unsplash.com/photo-1596649299486-4cdea56fd59d?q=80&w=2187&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', "It's Miles' way or the highway", '65677a22619a399a33aeef33');
INSERT INTO 
restaurants (name, imgUrl, description, creatorId)
VALUES ("MickDonalds", 'https://images.unsplash.com/photo-1464219222984-216ebffaaf85?q=80&w=2340&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', "It's Mick's way or the highway", '65496e4fb47d5e23a481b288');


CREATE TABLE IF NOT EXISTS reports(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title CHAR(50) NOT NULL,
  body VARCHAR(500) NOT NULL,
  pictureOfDisgust VARCHAR(1000),
  restaurantId INT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (restaurantId) REFERENCES restaurants(id) ON DELETE CASCADE,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';