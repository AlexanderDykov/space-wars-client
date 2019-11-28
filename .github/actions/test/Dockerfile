# Container image that runs your code
FROM gableroux/unity3d:${INPUT_VERSION}

RUN apt-get -y update && apt-get -y install git-core

COPY test.sh /test.sh

ENTRYPOINT ["/test.sh"]