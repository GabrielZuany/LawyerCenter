docker pull docker.elastic.co/kibana/kibana:8.13.0

docker run --name kib01 --net elastic -p 5601:5601 docker.elastic.co/kibana/kibana:8.13.0

# docker exec -it es01 /usr/share/elasticsearch/bin/elasticsearch-create-enrollment-token -s kibana
# docker exec -it es01 /usr/share/elasticsearch/bin/elasticsearch-reset-password -u elastic

