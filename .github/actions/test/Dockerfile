# Container image that runs your code
ARG IMAGE=gableroux/unity3d:2019.1.14f1
FROM $IMAGE

RUN apt-get -y update && apt-get -y install git-core

COPY test.sh /test.sh

ENTRYPOINT ["/test.sh"]