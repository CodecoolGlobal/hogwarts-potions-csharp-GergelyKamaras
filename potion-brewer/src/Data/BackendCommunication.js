export default async function FetchData(url)
{
    return fetch(url).then((response) => {
        if (!response.ok)
        {
            throw new Error("Error retrieving data!");
        }
        return response.json();
    }).catch(e => console.log(e));
}
