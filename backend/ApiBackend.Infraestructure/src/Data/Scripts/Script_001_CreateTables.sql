CREATE TABLE IF NOT EXISTS polls (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    name VARCHAR(255) NOT NULL,
    createdAt TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS options (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    name VARCHAR(255) NOT NULL,
    votes INTEGER NOT NULL DEFAULT 0,
    pollId UUID NOT NULL,
    FOREIGN KEY (pollId) REFERENCES polls(id) ON DELETE CASCADE 
);

CREATE TABLE IF NOT EXISTS votes (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    pollId UUID NOT NULL,
    optionId UUID NOT NULL,
    voterEmail VARCHAR(255) NOT NULL,
    votedAT TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (pollId) REFERENCES polls(id) ON DELETE CASCADE,
    FOREIGN KEY (optionId) REFERENCES options(id) ON DELETE CASCADE,
    UNIQUE(pollId, voterEmail)
);

