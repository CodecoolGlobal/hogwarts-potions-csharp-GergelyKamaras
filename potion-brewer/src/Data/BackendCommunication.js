export default async function FetchData(url)
{
    return fetch(url).then(async (response) => {
        if (!response.ok)
        {
            throw new Error("Error retrieving data!");
        }
        return await response.json(data => data);
    })
}
