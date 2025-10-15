
INSERT INTO user_role (name) VALUES ('EventCreator');
INSERT INTO user_role (name) VALUES ('EventParticipant');

INSERT INTO "user" (name, email, password_hash, phone_number, user_role_id) VALUES ('creatorUser', 'creator@email.com', 'hashedpassword1', '1234567890', 1);
INSERT INTO "user" (name, email, password_hash, phone_number, user_role_id) VALUES ('participantUser', 'participant@email.com', 'hashedpassword2', '0987654321', 2);
