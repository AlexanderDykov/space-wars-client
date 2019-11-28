# Container image that runs your code
ENV image gableroux/unity3d:${INPUT_VERSION}

FROM $image

RUN apt-get -y update && apt-get -y install git-core

COPY test.sh /test.sh

ENTRYPOINT ["/test.sh"]