# Container image that runs your code
FROM gableroux/unity3d:2019.1.14f1

RUN apt-get -y update && apt-get -y install git-core

COPY test.sh /test.sh

ENTRYPOINT ["/test.sh"]