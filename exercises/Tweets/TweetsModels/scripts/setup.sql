create database etec_aspnet_tweets;

create user 'etec_aspnet_tweets'@'localhost' identified by '12345678';
grant all privileges on etec_aspnet_tweets.* to 'etec_aspnet_tweets'@'localhost';

create table tweet (
    id int primary key auto_increment,
    text varchar(280) not null,
    user varchar(50) not null,
    created_at datetime not null,
    likes_count int not null,
    retweets_count int not null,
    replies_count int not null
);
