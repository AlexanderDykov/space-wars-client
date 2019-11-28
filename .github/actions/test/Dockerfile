FROM $IMAGE

RUN apt-get -y update && apt-get -y install git-core

COPY test.sh /test.sh

ENTRYPOINT ["/test.sh"]