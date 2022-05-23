INSERT INTO DepositStatuses (STATUS, DESCRIPTION)
VALUES 
('NONE', 'Deposit is not required'), 
('REQUIRED', 'Deposit is required, but not paid'), 
('PAID', 'A customer paid the deposit'), 
('RETURNED', 'Deposit is turned back to a customer'),
('SUSPENDEND', 'Deposit is suspended; it is waiting for the decison.'),
('TAKEN', 'Deposit was taken by the owner.'); 